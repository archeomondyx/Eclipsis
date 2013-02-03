using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EISModuleComponents;
using System.Reflection;
using System.IO;
namespace Eclipsis
{
    class EISModuleServices:EISModuleHost
    {
        private Types.AvailableEISModules allAvailableModules = new Types.AvailableEISModules();

        public Types.AvailableEISModules AllAvailableModules
        {
            get { return allAvailableModules; }
            set { allAvailableModules = value; }
        }


        public void FindModules(string path)
        {

            allAvailableModules.Clear();

            foreach (string fileOn in Directory.GetFiles(path))
            {
                FileInfo file = new FileInfo(fileOn);

                if (file.Extension.Equals(".dll"))
                {
                    try
                    {
                        this.Addmodule(fileOn);
                    }
                    catch (Exception e)
                    {
                        this.Notify("Error while loading module: \n" + e.TargetSite.ToString() + "\nReason:\n" + e.Message , EISErrorTypes.Error);
                    }
                }

            }

        }

        public Types.AvailableEISModules searchForAvailableModules(string path)
        {
            Types.AvailableEISModules foundModules = new Types.AvailableEISModules();

            foreach (string fileOn in Directory.GetFiles(path))
            {
                FileInfo file = new FileInfo(fileOn);

                if (file.Extension.Equals(".dll"))
                {
                    try
                    {
                        Addmodule(fileOn, foundModules);
                    }
                    catch (Exception e)
                    {
                        this.Notify("Error while loading module: \n" + e.TargetSite.ToString() + "\nReason:\n" + e.Message, EISErrorTypes.Error);
                    }
                }

            }

            return foundModules;
        }

        private void Addmodule(string fileName, Types.AvailableEISModules Modules)
        {
            Assembly moduleAssembly = Assembly.LoadFrom(fileName);

            foreach (Type moduleType in moduleAssembly.GetTypes())
            {
                if (moduleType.IsPublic)
                {
                    if (!moduleType.IsAbstract)
                    {
                        Type typeInterface = moduleType.GetInterface("EISModuleComponents.EISModule", true);

                        if (typeInterface != null)
                        {
                            try
                            {
                                Types.AvailableEISModule newmodule = new Types.AvailableEISModule();
                                newmodule.AssemblyPath = fileName;
                                newmodule.Instance = (EISModule)Activator.CreateInstance(moduleType);
                                newmodule.Instance.HostModule = this;
                                newmodule.Instance.InitializeModule();

                                Modules.Add(newmodule);

                                newmodule = null;
                            }
                            catch (Exception e)
                            {
                                 this.Notify("Error while loading module: \n" + e.TargetSite.ToString() + "\nReason:\n" + e.Message,EISErrorTypes.Error);
                            }
                        }
                        typeInterface = null;

                    }
                }
            }
            moduleAssembly = null;

        }



        public void Addmodule(string fileName)
        {
            Assembly moduleAssembly = Assembly.LoadFrom(fileName);

            foreach (Type moduleType in moduleAssembly.GetTypes())
            {
                if (moduleType.IsPublic)
                {
                    if (!moduleType.IsAbstract)
                    {
                        Type typeInterface = moduleType.GetInterface("EISModuleComponents.EISModule", true);

                        if (typeInterface != null)
                        {
                            try
                            {
                                Types.AvailableEISModule newmodule = new Types.AvailableEISModule();
                                newmodule.AssemblyPath = fileName;
                                newmodule.Instance = (EISModule)Activator.CreateInstance(moduleType);
                                newmodule.Instance.HostModule = this;
                                newmodule.Instance.InitializeModule();

                                this.allAvailableModules.Add(newmodule);

                                newmodule = null;
                            }
                            catch (Exception e)
                            {
                               this.Notify("Error while loading module: \n" + e.TargetSite.ToString() + "\nReason:\n" + e.Message, EISErrorTypes.Error);
                            }
                        }
                        typeInterface = null;

                    }
                }
            }
            moduleAssembly = null;

        }

        public void CloseModules()
        {
            foreach (Types.AvailableEISModule plug in allAvailableModules)
            {
                plug.Instance.DisposeModule();
                plug.Instance = null;
            }
            allAvailableModules.Clear();

        }

        public GlobalServices Services
        {
            get { throw new NotImplementedException(); }
        }


        public void Notify(string ErrorMessage, EISErrorTypes ErrorType)
        {
           // throw new NotImplementedException();
        }


        public void SetStatus(string status)
        {
            //throw new NotImplementedException();
        }

        public System.Windows.Forms.ToolStripProgressBar Progressbar
        {
            get { return null; }
        }


        public void WriteToLog(string message)
        {
            throw new NotImplementedException();
        }
    }
}


namespace Types
{
    public class AvailableEISModules : System.Collections.CollectionBase
    {
        public void Add(Types.AvailableEISModule module)
        {
            this.List.Add(module);
        }

        public void Remove(Types.AvailableEISModule module)
        {
            this.List.Remove(module);
        }

        public Types.AvailableEISModule Find(string nameOrPath)
        {
            Types.AvailableEISModule ret = null;

            foreach (Types.AvailableEISModule plug in this.List)
            {
                if ((plug.Instance.ModuleName.Equals(nameOrPath)) || (plug.AssemblyPath.Equals(nameOrPath)))
                {
                    ret = plug;
                    break;
                }
            }

            return ret;
        }
    }

    public class AvailableEISModule
    {

        private EISModule instance = null;
        private string assemblyPath = "";


        public EISModule Instance
        {
            get { return instance; }
            set { instance = value; }
        }


        public string AssemblyPath
        {
            get { return assemblyPath; }
            set { assemblyPath = value; }
        }

    }
}
   