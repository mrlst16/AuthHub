﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthHub.DAL.Sql
{
    internal static class SqlExtensions
    {
        internal static bool HasDataForTable(this DataSet dataSet, int index, out DataTable dataTable)
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

            dataTable = new DataTable();
            return false;
        }

        internal static bool HasDataForTable(this DataSet dataSet, int index, out DataRow row, int rowIndex = 0)
        {
            if(dataSet.HasDataForTable(index, out DataTable table))
            {
                row = table.Rows[rowIndex];
            }
            row = null;
            return false;
        }
    }
}