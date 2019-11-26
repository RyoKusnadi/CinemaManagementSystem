﻿using MySql.Data.MySqlClient;
using System.Data;
using System;

namespace CN_Business
{
    public class CinemaApprovalService
    {
        MySqlDataAdapter adapter;
        MySqlCommand cmd;
        DBConnection DBCon;
        DataTable dt;
        string sql;
        public DataTable getrequestdata()
        {

            DBCon = new DBConnection();
            sql = string.Format(@"SELECT requestor,cinema,movie_name,class,date,price FROM `bookingcinema` where isapprove is null");
            dt = new DataTable();
            try
            {
                DBCon.ConnectionOpen();
                cmd = new MySqlCommand(sql, DBCon.Connection);
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            DBCon.ConnectionClose();
            return dt;
        }

        public void approvedata(string requestor,string cinema,string movie_name,string kelas,DateTime date)
        {

            DBCon = new DBConnection();
            sql = string.Format(@"UPDATE `bookingcinema` SET ISAPPROVE=1 where requestor='" + requestor + "'and cinema='" + cinema + "'and movie_name='" + movie_name+ "'and Class='" + kelas+ "'and Date='" + date+ "'");
            dt = new DataTable();
            try
            {
                DBCon.ConnectionOpen();
                cmd = new MySqlCommand(sql, DBCon.Connection);
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            DBCon.ConnectionClose();
        }
        public void rejectdata(string requestor, string cinema, string movie_name, string kelas, DateTime date)
        {

            DBCon = new DBConnection();
            sql = string.Format(@"UPDATE `bookingcinema` SET ISAPPROVE=1 where requestor='" + requestor + "'and cinema='" + cinema + "'and movie_name='" + movie_name + "'and Class='" + kelas + "'and Date='" + date + "'");
            dt = new DataTable();
            try
            {
                DBCon.ConnectionOpen();
                cmd = new MySqlCommand(sql, DBCon.Connection);
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            DBCon.ConnectionClose();
        }
    }
}
