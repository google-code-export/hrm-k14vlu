using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;

namespace WebManagement.Common
{
    public class CommonMethods
    {
        public static List<CustomizeSubjectType> GetListCustomizeSubjectType()
        {
            List<CustomizeSubjectType> result = new List<CustomizeSubjectType>();
            result.Add(new CustomizeSubjectType { TypeID = 0, TypeName = "Chuyên nghành" });
            result.Add(new CustomizeSubjectType { TypeID = 1, TypeName = "Đại cương" });
            return result;
        }

        public static List<CustomizeSemester> GetListCustomizeSemester()
        {
            List<CustomizeSemester> result = new List<CustomizeSemester>();
            result.Add(new CustomizeSemester { ID = 1, Name = "Học kỳ 1" });
            result.Add(new CustomizeSemester { ID = 2, Name = "Học kỳ 2" });
            result.Add(new CustomizeSemester { ID = 3, Name = "Học kỳ hè" });
            return result;
        }

        public static List<CustomizeYear> GetListCutomizeYear()
        {
            List<CustomizeYear> result = new List<CustomizeYear>();
            for (int i = 2007; i < DateTime.Now.Year; i++)
            {
                result.Insert(0, new CustomizeYear { ID = i, Name = i.ToString() + " - " + (i + 1).ToString() });
            }
            return result;
        }

        public static List<CustomizeServerType> GetListCustomizeServerType()
        {
            List<CustomizeServerType> result = new List<CustomizeServerType>();
            result.Add(new CustomizeServerType { TypeID = 0, TypeName = "Nội bộ" });
            result.Add(new CustomizeServerType { TypeID = 1, TypeName = "Internet" });
            return result;
        }

        public static List<CustomizeLinkType> GetListCustomizeLinkType()
        {
            List<CustomizeLinkType> result = new List<CustomizeLinkType>();
            result.Add(new CustomizeLinkType { TypeID = 1, TypeName = "Ẩn" });
            result.Add(new CustomizeLinkType { TypeID = 2, TypeName = "Hiện" });
            result.Add(new CustomizeLinkType { TypeID = 3, TypeName = "Chữ đỏ" });
            result.Add(new CustomizeLinkType { TypeID = 4, TypeName = "Nổi bật" });
            return result;
        }

        public static List<CustomizeBranch> GetListCustomizeBrach()
        {
            List<CustomizeBranch> result = new List<CustomizeBranch>();
            result.Add(new CustomizeBranch { ID = 1, Name = "Cơ sở 1" });
            result.Add(new CustomizeBranch { ID = 2, Name = "Cơ sở 2" });
            return result;
        }

        public static Dictionary<string, string> GetListThemes()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add(ApplicationTheme.Expression_DarkTheme, "Expression Dark");
            result.Add(ApplicationTheme.MetroTheme, "Metro");
            result.Add(ApplicationTheme.Office_BlackTheme, "Office Black");
            result.Add(ApplicationTheme.Office_BlueTheme, "Office Blue");
            result.Add(ApplicationTheme.Office_SilverTheme, "Office Silver");
            result.Add(ApplicationTheme.SummerTheme, "Summer");
            result.Add(ApplicationTheme.TransparentTheme, "Transparent");
            result.Add(ApplicationTheme.VistaTheme, "Vista");
            result.Add(ApplicationTheme.Windows7Theme, "Windows 7");
            return result;
        }
    }

    public sealed class ApplicationTheme
    {
        public const string Expression_DarkTheme = "Expression_DarkTheme";
        public const string MetroTheme = "MetroTheme";
        public const string Office_BlackTheme = "Office_BlackTheme";
        public const string Office_BlueTheme = "Office_BlueTheme";
        public const string Office_SilverTheme = "Office_SilverTheme";
        public const string SummerTheme = "SummerTheme";
        public const string TransparentTheme = "TransparentTheme";
        public const string VistaTheme = "VistaTheme";
        public const string Windows7Theme = "Windows7Theme";
    }

    public sealed class KeySetting
    {
        public const string Theme = "Theme";
        public const string PagingSize = "PagingSize";
    }

    public static class CommonParams
    {
        public static object ParamEdit;
    }
}
