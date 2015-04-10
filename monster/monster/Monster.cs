using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monster
{
    class Monster
    {
        public byte age { get { return _age; } } //возраст
        public byte shape { get { return _shape; } } //вес
        public byte hunger { get { return _hunger; } } //голод
        public byte toilet { get { return _toilet; } } //туалет
        public byte sleep { get { return _sleep; } } //сон
        public byte hp { get { return _hp; } } //здоровье

        public bool isEat { get { return _isEat; } } //кушает
        public bool isPlay { get { return _isPlay; } } //играет
        public bool isLaze { get { return _isLaze; } } //бездельничает
        public bool isToilet { get { return _isToilet; } } //ходит в туалет
        public bool isSleep { get { return _isSleep; } } //спит
        public bool isSick { get { return _isSick; } } //болеет

        private byte _age=1;
        private byte _shape=1;
        private byte _hunger=5;
        private byte _toilet=5;
        private byte _sleep=5;
        private byte _hp=5;

        private bool _isEat=false;
        private bool _isPlay=false;
        private bool _isLaze = true;
        private bool _isToilet = false;
        private bool _isSleep = false;
        private bool _isSick = false;


        //кормить
        //данный метод увеличивает показатель голода _hunger, и уменьшает соответсвенно показатель хочу в туалет _toilet
        public void giveFood()
        {
            if (_hunger < 5)
            {
                _hunger++;
                if (_toilet > 1)
                {
                    _toilet--;
                }
                _isEat = true;

                _isSleep = false;
                _isLaze = false;
                _isPlay = false;
                _isSick = false;
                _isToilet = false;
            }
            else
            {
                shapeAdd();
            }
        }

        //лечить
        public void giveDrug()
        {
            if (_hp < 5)
            {
                _hp++;
                _isSick = false;
            }
        }

        public void sleeping()
        {
            if(_sleep<5)
            {
                _sleep++;
                _isSleep = true;

                _isEat = false;
                _isLaze = false;
                _isPlay = false;
                _isSick = false;
                _isToilet = false;
            }
        }

        public void toileting()
        {
            if (_toilet == 1)
            {
                _toilet+=4;
                _isToilet = true;

                _isEat = false;
                _isLaze = false;
                _isPlay = false;
                _isSick = false;
                _isSleep = false;
            }
        }

        public void ageAdd()
        {
            if (_age < 3)
            {
                _age++;
            }
        }

        public void shapeAdd()
        {
            if (_shape < 3)
            {
                _shape++;
            }
        }

        public void game()
        {
            if (_sleep > 1)
            {
                _sleep--;
            }

            if (_hunger > 1)
            {
                _hunger--;
            }

            if (_hunger >= 3 && _toilet >= 3 && _sleep >= 3 && _hp >= 3)
            {
                _isPlay = true;

                _isEat = false;
                _isLaze = false;
                _isToilet = false;
                _isSick = false;
                _isSleep = false;
            }
            else
            {
                _isLaze = true;

                _isEat = false;
                _isToilet = false;
                _isPlay = false;
                _isSick = false;
                _isSleep = false;
            }
        }

        public void ill()
        {
            if (_hp > 1)
            {
                _hp--;
               
            }
            if (_hp == 1)
            {
                _isSick = true;

                _isEat = false;
                _isToilet = false;
                _isPlay = false;
                _isLaze = false;
                _isSleep = false;
            }
        }

    }
}
