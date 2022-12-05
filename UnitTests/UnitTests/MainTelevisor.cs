using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TvSet
{
        class TvSet
        {
            private int selectedCh = 1;
            private int prevCh = 0;
            private bool isOn = false;

            public bool TurnOff()
            {
                return isOn = false;
            }

            public bool TurnOn()
            {
                return isOn = true;
            }

            public bool SelectChannel(int channel)
            {
                bool res = false;
                if (1 <= channel && channel <= 99 && isOn)
                {
                    res = true;
                    prevCh = selectedCh;
                    selectedCh = channel;
                }
                return res;
            }

            public int GetChannel()
        {
            if (isOn)
            {
                return selectedCh;
            }
            return 0;
        }

            public bool SelectPreviousChannel()
            {
                if (isOn && prevCh != 0)
                {
                    (selectedCh, prevCh) = (prevCh, selectedCh);
                    return true;
                }
                return false;
            }

            public bool SelectChannelAfter()
            {
                if (isOn)
                {
                    prevCh = selectedCh;
                    if (selectedCh == 99)
                    {
                        selectedCh = 1;
                    }
                    else
                    {
                        selectedCh++;
                    }
                    return true;
                }
                return false;
            }

            public bool SelectChannelBefore()
            {
                if (isOn)
                {
                    prevCh = selectedCh;
                    if (selectedCh == 1)
                    {
                        selectedCh = 99;
                    }
                    else
                    {
                        selectedCh--;
                    }
                    return true;
                }
                return false;
            }
        };
}
