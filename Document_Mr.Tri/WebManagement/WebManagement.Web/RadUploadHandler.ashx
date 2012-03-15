<%@ WebHandler Language="C#" Class="RadUploadHandler" %>

using System;
using System.Web;

public class RadUploadHandler : Telerik.Windows.RadUploadHandler
{
    public override System.Collections.Generic.Dictionary<string, object> GetAssociatedData()
    {
        System.Collections.Generic.Dictionary<string,object> dict = new System.Collections.Generic.Dictionary<string,object>();

        string clientParamValue = this.GetQueryParameter("MyParam1");
        if (clientParamValue != null)
        {
            dict.Add("MyServerParam1",
                String.Format("Server_Value\n[{0}]\nThe file name is\n[{1}]",
                clientParamValue,
                this.Request.Form[Telerik.Windows.Controls.RadUploadConstants.ParamNameFileName]));
        }
        
        return dict;
    }
}