using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.DAL.Sql
{
    internal static class SqlExtensions
    {
        internal static bool HasDataForTable(this DataSet dataSet, int index, out DataTable? dataTable)
        {
            if (dataSet != null
                && dataSet.Tables != null
                && dataSet.Tables.Count > 0
                && dataSet.Tables.Count > index
                && dataSet.Tables[index] != null)
            {
                dataTable = dataSet.Tables[index];
                return true;
            }

            dataTable = null;
            return false;
        }

        internal static bool HasDataForRow(this DataTable table, int index, out DataRow? dataRow)
        {
            if (table != null
                && table.Rows != null
                && table.Rows.Count > 0
                && table.Rows.Count < index
                && table.Rows[index] != null
                )
            {
                dataRow = table.Rows[index];
                return true;
            }
            dataRow = null;
            return false;
        }
    }
} 