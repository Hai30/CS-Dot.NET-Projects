using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
   public class ValueOutOfRangeException:Exception
    {

        private float m_minValue;
        private float m_maxValue;
        private string m_message;

        public ValueOutOfRangeException(float i_minValue, float i_maxValue, string i_message)
        {

            this.m_minValue = i_minValue;
            this.m_maxValue = i_maxValue;
            this.m_message = i_message;
        }

        public float MinValue
        {
            get
            {
                return m_minValue;
            }
        }

        public float MaxValue
        {
            get
            {
                return m_maxValue;
            }
        }

        public override string Message
        {
            get
            {
                return m_message;
            }
        }

    }
}
