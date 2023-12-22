namespace ADCS.Domain
{
    public class Instruction
    {
        public string FieldInput { get; set; }
        public string PositionInput { get; set; }
        public string Commands { get; set; }

        public Instruction() { }
        public Instruction(string fieldInput, string positionInput, string commands)
        {
            FieldInput = fieldInput;
            PositionInput = positionInput;
            Commands = commands;
        }

    }
}
