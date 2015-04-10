using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace monster
{
    class DayNight
    {
        private byte ppartDay=0;
        private byte ppartNight=0;
        private bool pisDayNight=true;

        public byte partDay { get { return ppartDay; } }//часть дня
        public byte partNight { get { return ppartNight; } }//часть ночи
        public bool isDayNight { get { return pisDayNight; } }

        //меняет день на ночь и обратно
        //день и ночь деляться на 4 части каждый, каждая часть длиться 3 секунды
        //если прошло 4 части дня -> наступает ночь, и наоборот
        public void startDayNigth()
        {
            while (true)
            {
                if (ppartDay == 4)
                {
                    pisDayNight = false;
                    ppartDay = 0;
                }

                if (ppartNight == 4)
                {
                    pisDayNight = true;
                    ppartNight = 0;
                }

                if (ppartDay < 4 && pisDayNight==true)
                {
                    ppartDay++;
                }

                if (ppartNight < 4 && pisDayNight == false)
                {
                    ppartNight++;
                }
                if (TimeChange != null)
                {
                    TimeChange(this, new EventArgs());
                }
                Thread.Sleep(3000);
            }
        }

        public event EventHandler<EventArgs> TimeChange;
    }
}
