using System.Runtime.InteropServices;

namespace ChangeInternetInterface
{
    public class Test1
    {
        //最近网络老是不太好，下东西时总是断线，所以就想做一个自动连接的程序，在网上搜了一上，就把代理记录下来了，希望对大家有帮助

        [DllImport("wininet.dll")]
        private static extern bool InternetCheckConnection(String url, int flag, int ReservedValue);

        /// <summary>
        /// 第一步.检测外网的一个网站，如www.baidu.com
        /// </summary>
        /// <returns></returns>
        public bool GetExtranet()
        {
            bool extranet = false;
            try
            {
                if (InternetCheckConnection("http://www.baidu.com/", 1, 0).Equals(false))
                {
                    extranet = false;
                }
                else
                {
                    extranet = true;
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }

            return extranet;
        }

        //禁用 SetNetworkAdapter(False)
        //启用 SetNetworkAdapter(True)
        //添加引用system32\shell32.dll
        private static bool SetNetworkAdapter(bool status)
        {
            const string discVerb = "停用(&B)"; // "停用(&B)";
            const string connVerb = "启用(&A)"; // "启用(&A)";
            const string network = "网络连接"; //"网络连接";
            const string networkConnection = "VMware Network Adapter VMnet1"; // "本地连接"

            string sVerb = null;

            if (status)
            {
                sVerb = connVerb;
            }
            else
            {
                sVerb = discVerb;
            }

            Shell32.Shell sh = new Shell32.Shell();
            Shell32.Folder folder = sh.NameSpace(Shell32.ShellSpecialFolderConstants.ssfCONTROLS);

            try
            {
                //进入控制面板的所有选项
                foreach (Shell32.FolderItem myItem in folder.Items())
                {
                    //进入网络连接
                    if (myItem.Name == network)
                    {
                        Shell32.Folder fd = (Shell32.Folder)myItem.GetFolder;
                        foreach (Shell32.FolderItem fi in fd.Items())
                        {
                            //找到本地连接
                            if ((fi.Name == networkConnection))
                            {
                                //找本地连接的所有右键功能菜单
                                foreach (Shell32.FolderItemVerb Fib in fi.Verbs())
                                {
                                    if (Fib.Name == sVerb)
                                    {
                                        Fib.DoIt();
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }
    }
}