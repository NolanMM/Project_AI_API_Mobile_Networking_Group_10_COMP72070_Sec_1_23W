﻿using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Runtime.InteropServices;
using IronXL;
using xl = Microsoft.Office.Interop.Excel;
using XLs = Spire.Xls;
using Spire.Xls.Core.Spreadsheet;
using server;
using System.Linq;
using System.Windows.Forms;

namespace server
{
    public static class ExcelApiTest
    {
        public static void Function_Excel_Login(string username, string password)
        {
            WorkBook wb = WorkBook.Load("sample.xlsx");
            WorkSheet ws = wb.GetWorkSheet("Sheet1");

            string raw_material = username;
            string UserID = Encryption_.ComputeSha256Hash(raw_material);

            string key = "Empty";
            string data_result = "Empty";
            //Traverse all rows of Excel WorkSheet
            for (int i = 0; i < ws.Rows.Count(); i++)
            {
                //Traverse all columns of specific Row
                for (int j = 0; j < ws.Columns.Count(); j++)
                {
                    //Get the values of UserID if it match with hashing code from hashing
                    string val = ws.Rows[i].Columns[0].Value.ToString();
                    if (val == UserID)
                    {
                        // Assign the key
                        key = ws.Rows[i].Columns[0].Value.ToString();
                        // Take the encypted data out
                        data_result = ws.Rows[i].Columns[1].Value.ToString();
                    }

                }
            }
            // Take 16 chars for the key to decypted the data in the second column in the same row
            string public_key = UserID.Substring(0, 8);
            string secret_key = UserID.Substring(8, 8);
            string decrypted_data = Encryption_.Decrypt(data_result, public_key, secret_key);

            string[] Items = decrypted_data.Split('-');
            // string Items[0] = Username
            // string Items[1] = Password;
            // string Items[2] = Email;

            if (Items[1] == password)
            {
                //Console.WriteLine(Items[0]);
                //Console.WriteLine(Items[1]);
                //Console.WriteLine(Items[2]);

                //Console.WriteLine("Login function build successfully\n");
                //Console.WriteLine("The data of the user are\n");
                //Console.WriteLine(decrypted_data);
                //Console.ReadLine();

                MessageBox.Show("LoginSuccessful", "Warning");
                MessageBox.Show(decrypted_data, "Warning");

            }
            else
            {
                Console.WriteLine("Errors");
                Console.ReadLine();
            }


        }
        public static class Server_SignUp
        {
            public static void Sign_Up(string username,string password,string email)
            {
                // Generate Sample data by Hard Code

                //string username = "minhlenguyen02";
                //string password = "Connhenbeo1";
                //string email = "minhlenguyen02@gmail.com";

                // Generate Unique hashing code for each Username+Password Combination and Make it the unique UserID
                // And take 16 char in the hashing code for the encyption key for the data of user - final string
                bool Flag = Check_If_Duplicate_Username(username);
                if (Flag != true)
                {
                    string raw_material = username;
                    string UserID = Encryption_.ComputeSha256Hash(raw_material);

                    // Take 16 chars from userID for the key for AES the data
                    string public_key = UserID.Substring(0, 8);
                    string secret_key = UserID.Substring(8, 8);

                    // Combine all the data together
                    string final_string = username + "-" + password + "-" + email;

                    // Encypted the final_string (User data) by the key
                    string write_to_file_encypted_data = Encryption_.Encrypt(final_string, public_key, secret_key);

                    // Combine the encypted data with the key and store it into the file first for test
                    //string store_data = UserID + "-" + write_to_file_encypted_data;
                    ExcelApiTest.Write_To_Excel(UserID, write_to_file_encypted_data);

                    //System.IO.File.AppendAllText(@"./Test.txt", store_data + "\n");

                    MessageBox.Show("Sign Up Successful", "Warning");
                }
                else { MessageBox.Show("Duplicate Username", "Warning"); }

            }

        }
        public static bool Check_If_Duplicate_Username(string username)
        {
            WorkBook wb = WorkBook.Load("sample.xlsx");
            WorkSheet ws = wb.GetWorkSheet("Sheet1");

            string raw_material = username;
            string UserID = Encryption_.ComputeSha256Hash(raw_material);

            bool key = false;
            //Traverse all rows of Excel WorkSheet
            for (int i = 0; i < ws.Rows.Count(); i++)
            {
                //Traverse all columns of specific Row
                for (int j = 0; j < ws.Columns.Count(); j++)
                {
                    //Get the values of UserID if it match with hashing code from hashing
                    string val = ws.Rows[i].Columns[0].Value.ToString();
                    if (val == UserID)
                    {
                        // Assign the key
                        key = true;
                    }

                }
            }
            return key;
        }
        public static void Write_To_Excel(string key, string encrypted_data)
        {
            //Create a Workbook object
            XLs.Workbook workbook = new XLs.Workbook();
            workbook.LoadFromFile("sample.xlsx");
            //Remove default worksheets
            //workbook.Worksheets.Clear();
            //Add a worksheet and name it
            XLs.Worksheet worksheet = workbook.Worksheets[0];
            //Write data to specific cells
            int index_pos = workbook.Worksheets[0].Rows.Count();
            worksheet.Range[index_pos + 1, 1].Value = key;
            worksheet.Range[index_pos + 1, 2].Value = encrypted_data;

            //Auto fit column width
            //worksheet.AllocatedRange.AutoFitColumns();
            //Save to an Excel file
            workbook.SaveToFile("sample.xlsx", XLs.ExcelVersion.Version2016);
        }

    }
}