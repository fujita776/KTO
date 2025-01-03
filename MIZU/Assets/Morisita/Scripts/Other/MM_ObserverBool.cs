    public class MM_ObserverBool
    {

        private bool oldBool;
        private bool newBool;

        bool onBoolChange;
        bool onBoolTrueChange;
        bool onBoolFalseChange;

        private bool _Bool
        {
            set
            {
                oldBool = newBool;
                newBool = value;

                if (oldBool == newBool)
                {
                    onBoolChange = false;
                    onBoolTrueChange = false;
                    onBoolFalseChange = false;
                }
                else
                {
                    onBoolChange = true;
                    if (newBool)
                    {
                        onBoolTrueChange = true;
                        onBoolFalseChange = false;
                    }
                    else
                    {
                        onBoolTrueChange = false;
                        onBoolFalseChange = true;
                    }
                }

            }
        }
        public MM_ObserverBool() { }
        public MM_ObserverBool(bool inBool)
        {
            SetBool(inBool);
        }
        public void SetBool(bool inBool)
        {
            _Bool = inBool;
        }

        /// <summary>
        /// Boolが変わった瞬間を返す
        /// </summary>
        /// <param name="inBool"></param>
        /// <returns></returns>
        public bool OnBoolChange(bool inBool)
        {
            SetBool(inBool);
            return onBoolChange;
        }

        /// <summary>
        /// BoolがTrueに変わった瞬間を返す
        /// </summary>
        /// <param name="inBool"></param>
        /// <returns></returns>
        public bool OnBoolTrueChange(bool inBool)
        {
            SetBool(inBool);

            return onBoolTrueChange;
        }

        /// <summary>
        /// BoolがFalseに変わった瞬間を返す
        /// </summary>
        /// <param name="inBool"></param>
        /// <returns></returns>
        public bool OnBoolFalseChange(bool inBool)
        {
            SetBool(inBool);
            return onBoolFalseChange;
        }
    }