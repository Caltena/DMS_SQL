namespace ADD
{
    public class cADD
    {
        public cADD()
        {
            this.Add_Key = 0;
        }

        public void SetADDKey(int ADD_Key)
        {
            this.Add_Key = ADD_Key;
        }

        public int GetADDKey()
        {
            return this.Add_Key;
        }

        public int Add_Key { get; set; }
    }
}
