using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadModel : Singleton<LoadModel>
{
    public class playerDate{
        private int id;
        private string pot;
        private string time;
        private int playerTime;
        private string headName;

        public int Id
        {
            get
            {
                return id;
            }

            set 
            {
                id = value;
            }
        }

        public string Time
        {
            get
            {
                return time;
            }

            set 
            {
                time = value;
            }
        }

        public int PlayerTime
        {
            get
            {
                return playerTime;
            }

            set 
            {
                playerTime = value;
            }
        }

        public string HeadName
        {
            get
            {
                return headName;
            }

            set 
            {
                headName = value;
            }
        }
    }
    public playerDate[] allPlayer;

    private int countNum = 10;

    public int CountNum
    {
        get
        {
            return countNum;
        }
        set 
        {
            countNum = value;
        }
    }
}
