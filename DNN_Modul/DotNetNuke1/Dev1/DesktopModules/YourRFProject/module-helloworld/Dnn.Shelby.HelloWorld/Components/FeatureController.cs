/*
' Copyright (c) 2023 Shelby Company ltd
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

//using System.Xml;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;
using System.Collections.Generic;

namespace Shelby.Dnn.Dnn.Shelby.HelloWorld.Components
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Controller class for Dnn.Shelby.HelloWorld
    /// 
    /// The FeatureController class is defined as the BusinessController in the manifest file (.dnn)
    /// DotNetNuke will poll this class to find out which Interfaces the class implements. 
    /// 
    /// The IPortable interface is used to import/export content from a DNN module
    /// 
    /// The ISearchable interface is used by DNN to index the content of a module
    /// 
    /// The IUpgradeable interface allows module developers to execute code during the upgrade 
    /// process for a module.
    /// 
    /// Below you will find stubbed out implementations of each, uncomment and populate with your own data
    /// </summary>
    /// -----------------------------------------------------------------------------

    //uncomment the interfaces to add the support.
    public class FeatureController //: IPortable, ISearchable, IUpgradeable
    {
        

        #region Optional Interfaces

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ExportModule implements the IPortable ExportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be exported</param>
        /// -----------------------------------------------------------------------------
        //public string ExportModule(int ModuleID)
        //{
        //string strXML = "";

        //List<Dnn.Shelby.HelloWorldInfo> colDnn.Shelby.HelloWorlds = GetDnn.Shelby.HelloWorlds(ModuleID);
        //if (colDnn.Shelby.HelloWorlds.Count != 0)
        //{
        //    strXML += "<Dnn.Shelby.HelloWorlds>";

        //    foreach (Dnn.Shelby.HelloWorldInfo objDnn.Shelby.HelloWorld in colDnn.Shelby.HelloWorlds)
        //    {
        //        strXML += "<Dnn.Shelby.HelloWorld>";
        //        strXML += "<content>" + DotNetNuke.Common.Utilities.XmlUtils.XMLEncode(objDnn.Shelby.HelloWorld.Content) + "</content>";
        //        strXML += "</Dnn.Shelby.HelloWorld>";
        //    }
        //    strXML += "</Dnn.Shelby.HelloWorlds>";
        //}

        //return strXML;

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ImportModule implements the IPortable ImportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be imported</param>
        /// <param name="Content">The content to be imported</param>
        /// <param name="Version">The version of the module to be imported</param>
        /// <param name="UserId">The Id of the user performing the import</param>
        /// -----------------------------------------------------------------------------
        //public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        //{
        //XmlNode xmlDnn.Shelby.HelloWorlds = DotNetNuke.Common.Globals.GetContent(Content, "Dnn.Shelby.HelloWorlds");
        //foreach (XmlNode xmlDnn.Shelby.HelloWorld in xmlDnn.Shelby.HelloWorlds.SelectNodes("Dnn.Shelby.HelloWorld"))
        //{
        //    Dnn.Shelby.HelloWorldInfo objDnn.Shelby.HelloWorld = new Dnn.Shelby.HelloWorldInfo();
        //    objDnn.Shelby.HelloWorld.ModuleId = ModuleID;
        //    objDnn.Shelby.HelloWorld.Content = xmlDnn.Shelby.HelloWorld.SelectSingleNode("content").InnerText;
        //    objDnn.Shelby.HelloWorld.CreatedByUser = UserID;
        //    AddDnn.Shelby.HelloWorld(objDnn.Shelby.HelloWorld);
        //}

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// GetSearchItems implements the ISearchable Interface
        /// </summary>
        /// <param name="ModInfo">The ModuleInfo for the module to be Indexed</param>
        /// -----------------------------------------------------------------------------
        //public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(DotNetNuke.Entities.Modules.ModuleInfo ModInfo)
        //{
        //SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();

        //List<Dnn.Shelby.HelloWorldInfo> colDnn.Shelby.HelloWorlds = GetDnn.Shelby.HelloWorlds(ModInfo.ModuleID);

        //foreach (Dnn.Shelby.HelloWorldInfo objDnn.Shelby.HelloWorld in colDnn.Shelby.HelloWorlds)
        //{
        //    SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objDnn.Shelby.HelloWorld.Content, objDnn.Shelby.HelloWorld.CreatedByUser, objDnn.Shelby.HelloWorld.CreatedDate, ModInfo.ModuleID, objDnn.Shelby.HelloWorld.ItemId.ToString(), objDnn.Shelby.HelloWorld.Content, "ItemId=" + objDnn.Shelby.HelloWorld.ItemId.ToString());
        //    SearchItemCollection.Add(SearchItem);
        //}

        //return SearchItemCollection;

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpgradeModule implements the IUpgradeable Interface
        /// </summary>
        /// <param name="Version">The current version of the module</param>
        /// -----------------------------------------------------------------------------
        //public string UpgradeModule(string Version)
        //{
        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        #endregion

    }

}
