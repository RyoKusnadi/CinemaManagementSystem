﻿using MySql.Data.MySqlClient;
using System.Data;
using System;

namespace CN_Business
{
   public class CinemaService
    {
        public MySqlConnection Connection;
        MySqlDataAdapter adapter;
        MySqlConnection conn = new MySqlConnection("server=localhost; database=cinema_simd;  uid=root; pwd=;convert zero datetime=True");
        string query;

        public DataSet get_cinemas_data(DataSet dataset)
        {
            DataSet DataSetCinema = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                query = string.Format(@"select DISTINCT cinema_name from cinemas ");
                adapter = new MySqlDataAdapter(query, conn);
                DataSetCinema.Clear();
                adapter.Fill(DataSetCinema);
                conn.Close();
                return DataSetCinema;
            }
            conn.Close();
            return null;
        }
        public DataSet get_movies_data(DataSet ds, string cinema_name)
        {
            DataSet DataSetMovie = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                query = string.Format(@"select DISTINCT movie_name from cinemas where cinema_name= '"+ cinema_name + "'");
                adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(DataSetMovie);
                conn.Close();
                return DataSetMovie;
            }

            conn.Close();
            return null;
        }
        public DataSet get_moviedetail_data(DataSet ds, string movie_name)
        {
            DataSet DataSetMovie = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                query = string.Format(@"select DISTINCT cinema_name from cinemas where movie_name= '" + movie_name + "'");
                adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(DataSetMovie);
                conn.Close();
                return DataSetMovie;
            }

            conn.Close();
            return null;
        }
        public DataSet get_duration_data(DataSet ds, string movie_name)
        {
            DataSet DataSetDuration = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                query = string.Format(@"select DISTINCT duration from movies where movie_name= '" + movie_name + "'");
                adapter = new MySqlDataAdapter(query, conn);
                adapter.Fill(DataSetDuration);
                conn.Close();
                return DataSetDuration;
            }

            conn.Close();
            return null;
        }
        public DataSet get_dates_data(DataSet dataset,string Cinema_Name,string Movie_Name)
        {
            DataSet DSDate = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                query = string.Format(@"select DISTINCT date from cinemas where cinema_name= '" + Cinema_Name + "'and movie_name='" + Movie_Name +"'");
                adapter = new MySqlDataAdapter(query, conn);
                DSDate.Clear();
                adapter.Fill(DSDate);
                conn.Close();
                return DSDate;
            }

            conn.Close();
            return null;
        }
        public DataSet get_times_data(DataSet dataset, string Cinema_Name, string Movie_Name,string date)
        {
            DataSet DSTimes = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                query = string.Format(@"select DISTINCT time from cinemas where cinema_name= '" + Cinema_Name + "'and movie_name='" + Movie_Name + "'and date='" + date + "'");
                adapter = new MySqlDataAdapter(query, conn);
                DSTimes.Clear();
                adapter.Fill(DSTimes);
                conn.Close();
                return DSTimes;
            }

            conn.Close();
            return null;
        }
        public DataSet get_theater_data(DataSet dataset, string Cinema_Name, string Movie_Name, string date,string time)
        {
            DataSet DStheather = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                query = string.Format(@"select DISTINCT theather from cinemas where cinema_name= '" + Cinema_Name + "'and movie_name='" + Movie_Name + "'and date='" + date + "'and time='" + time + "'");
                adapter = new MySqlDataAdapter(query, conn);
                DStheather.Clear();
                adapter.Fill(DStheather);
                conn.Close();
                return DStheather;
            }

            conn.Close();
            return null;
        }
        public DataSet get_class_data(DataSet dataset, string Cinema_Name, string Movie_Name, string date, string time, string theather)
        {
            DataSet DSClass = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                query = string.Format(@"select DISTINCT class from cinemas where cinema_name= '" + Cinema_Name + "'and movie_name='" + Movie_Name + "'and date='" + date + "'and time='" + time + "'and theather='" + theather + "'");
                adapter = new MySqlDataAdapter(query, conn);
                DSClass.Clear();
                adapter.Fill(DSClass);
                conn.Close();
                return DSClass;
            }
            conn.Close();
            return null;
        }
        public DataSet get_cinemaid_data(DataSet dataset, string Cinema_Name, string Movie_Name, string date, string time, string theather)
        {
            DataSet DSClass = new DataSet();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                query = string.Format(@"select DISTINCT cinema_id from cinemas where cinema_name= '" + Cinema_Name + "'and movie_name='" + Movie_Name + "'and date='" + date + "'and time='" + time + "'and theather='" + theather + "'");
                adapter = new MySqlDataAdapter(query, conn);
                DSClass.Clear();
                adapter.Fill(DSClass);
                conn.Close();
                return DSClass;
            }
            conn.Close();
            return null;
        }

        public DataSet get_slide_data(DataSet dataset)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                query = string.Format(@"select DISTINCT movie_image,movie_name from movies");
                adapter = new MySqlDataAdapter(query, conn);
                dataset.Clear();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }
            conn.Close();
            return null;
        }
        public DataSet get_release_data(DataSet dataset)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                query = string.Format(@"select movie_name,movie_image from movies where movie_release <= '" + DateTime.Today.ToString("yyyy-MM-dd") + "' order by(movie_release) desc");
                adapter = new MySqlDataAdapter(query, conn);
                dataset.Clear();
                adapter.Fill(dataset);
                conn.Close();
                return dataset;
            }
            conn.Close();
            return null;
        }
        public DataTable get_seats_data(DataTable dataTable, string theather)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                query = string.Format(@"select seats from theather where theather_name = '" + theather + "'");
                adapter = new MySqlDataAdapter(query, conn);
                dataTable.Clear();
                adapter.Fill(dataTable);
                conn.Close();
                return dataTable;
            }
            conn.Close();
            return null;
        }
        public DataTable get_bookedtickets_data(DataTable dataTable, string cinema_id)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                query = string.Format(@"select seat_number from bookedtickets where cinema_id = '" + cinema_id + "'");
                adapter = new MySqlDataAdapter(query, conn);
                dataTable.Clear();
                adapter.Fill(dataTable);
                conn.Close();
                return dataTable;
            }
            conn.Close();
            return null;
        }
    }
}
