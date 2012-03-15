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

namespace WebManagement.Common
{
    public class CommonMethods
    {
        public const int PageSize = 20;

        public static int GetTotalPage(int pageSize, int totalItem)
        {
            int result = 0;
            result = totalItem / pageSize;
            if (totalItem % pageSize > 0)
                result++;
            return result;
        }
    }

    public static class CommonParams
    {
        public static object ParamEdit;
    }
}
