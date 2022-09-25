//namespace ChangeInternetInterface
//{
//    internal class Program
//    {
//        //禁用 SetNetworkAdapter(False)
//        //启用 SetNetworkAdapter(True)
//        //添加引用system32\shell32.dll

//        public static Shell32.Folder? GetShellFolder(Shell32.Folder inputFolder, string name)
//        {
//            //进入控制面板的所有选项
//            foreach (Shell32.FolderItem myItem in inputFolder.Items())
//            {
//                if (myItem.Name == name)
//                {
//                    return (Shell32.Folder)myItem.GetFolder;
//                }
//            }

//            return null;
//        }

//        public static void PrintShellFolder(Shell32.Folder inputFolder)
//        {
//            //进入控制面板的所有选项
//            foreach (Shell32.FolderItem myItem in inputFolder.Items())
//            {
//                Console.WriteLine(myItem.Name);
//            }
//        }

//        private static List<string> SetNetworkAdapter()
//        {
//            const string network = "网络连接"; //"网络连接";

//            Shell32.Shell sh = new Shell32.Shell();
//            Shell32.Folder folder = sh.NameSpace(Shell32.ShellSpecialFolderConstants.ssfCONTROLS);
//            var res = new List<string>();
//            try
//            {
//                //进入控制面板的所有选项
//                PrintShellFolder(folder);
//                var newShellFolder = GetShellFolder(folder, "网络和共享中心");
//                PrintShellFolder(newShellFolder);
//                var networkFolder = GetShellFolder(folder, network);
//                if (null == networkFolder) return res;
//                foreach (Shell32.FolderItem item in networkFolder.Items())
//                {
//                    res.Add(item.Name);
//                }
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//                return res;
//            }

//            return res;
//        }

//        [STAThread]
//        private static void Main(string[] args)
//        {
//            var newWorkList = SetNetworkAdapter();
//            for (int i = 0; i < newWorkList.Count; i++)
//            {
//                Console.WriteLine($"{i + 1} : {newWorkList[i]}");
//            }
//            Console.WriteLine("Hello, World!");
//            Console.ReadKey();//等待获取一个输入；
//        }
//    }
//}

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static System.Threading.Thread;
using System.Management;

namespace WMI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ManagementObjectSearcher networkAdapterSearcher = new ManagementObjectSearcher("root\\cimv2", "select * from Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objectCollection = networkAdapterSearcher.Get();

            Console.WriteLine("There are {0} network adapaters: ", objectCollection.Count);

            foreach (ManagementObject networkAdapter in objectCollection)
            {
                PropertyDataCollection networkAdapterProperties = networkAdapter.Properties;
                foreach (PropertyData networkAdapterProperty in networkAdapterProperties)
                {
                    if (networkAdapterProperty.Value != null)
                    {
                        Console.WriteLine("Network adapter property name: {0}", networkAdapterProperty.Name);
                        Console.WriteLine("Network adapter property value: {0}", networkAdapterProperty.Value);
                    }
                }
                Console.WriteLine("---------------------------------------");
            }
        }
    }
}