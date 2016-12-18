using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ravengard_console
{
    class BuildQuery
    {
        internal void getRockInfo(int key)
        {
            switch (key)
            {

                case 1:
                    {
                        Query SQL = new Query();
                        SQL.QueryMethod("Rock_Name,Rock_ID", "Rock");
                        break;
                    }
                case 2:
                    {
                        Query SQL = new Query();
                        SQL.QueryMethod("Holder_Name,Holder_ID", "RockHolder");
                        break;
                    }
                case 3:
                    {
                        Query SQL = new Query();
                        SQL.QueryMethod("RingType_Name,RingType_ID", "RingType");
                        break;
                    }
            }
        }
    }
}
