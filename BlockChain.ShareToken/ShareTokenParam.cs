using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.ShareToken
{
    public static class ShareTokenParam
    {
        #region APP 版本信息，要和 合约定义一样！

        public static string Version = @"20230301";

        // AppId 定义
        //钱包 2；
        //股份分红token 3；
        //3#T 6； 3#T平台相关的项目， 6**；
        //娱乐平台，9；娱乐平台项目， 9**；
        //NFT平台，8；NFT项目，8**；

        public static int AppId = 3;


        #endregion


        #region 合约部署 2023年8月18日更新 sepolia 网络


        public static string AddressDutchAuction
        {
            get
            {
                //return "0x48418623fd7079a6a6e607402d526d1d12b10619";    // "0xf05c3c120cdec6d25a5ccd97832ec52f1494dd82";                    //https://sepolia.etherscan.io/tx/0xda555dad4ff1a6a5e7ddf4ceef6a5f578d88e9dac1c1013d51f94c5ab083ff50
                return Share.BLL.AppInfo.GetKeyAddress("AddressDutchAuction");        //如果使用钱包合约
            }
        }

        public static string Address_ShareTokenFactory
        {
            get
            {
                //return "0xaaa640a1e75b167e8fd5f32b98af7fde8a5d7778";    // "0xf06298fba5df175b2ecc3a0482722ad6e2c399fd";                   //https://sepolia.etherscan.io/tx/0x307c339f58ec50e047ee698178abadbfd3d54372c3d25616d20f109af87e7ec2
                return Share.BLL.AppInfo.GetKeyAddress("AddressShareTokenFactory");        //如果使用钱包合约
            }
        }

        public static string Address_ShareTokenDexPairFactory
        {
            get
            {
                //return "0x684e47e8f4c41abd96d65be15f1828985a613d4b";    // "0x7f30f092ce6fecc981bd41222106ffbc44c07be6";                    //https://sepolia.etherscan.io/tx/0x6aa727fe95ce02230a657d63ca52f49e84f6dd2f54228a9dee80741127e493d7
                return Share.BLL.AppInfo.GetKeyAddress("AddressShareTokenDexPairFactory");        //如果使用钱包合约
            }
        }

        #endregion


        public const string DefaultDbFileName = "ShareTokenDb.mdf";

        public static string DefaultDbConStr 
        {
            get
            {
                string d1 = Path.Combine(Environment.CurrentDirectory, "DataBase");
                string d2 = Path.Combine(d1, DefaultDbFileName);

                string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + d2 + @";Integrated Security=True";

                return con;
            }
        }

        public static bool IsFirstRun
        {
            get
            {
                return Properties.Settings.Default.IsFirstRun;
            }
            set
            {
                Properties.Settings.Default.IsFirstRun = value;
                Properties.Settings.Default.Save();
            }
        }

    }

}
