using System;
namespace MarsRover
{
    public class Rover
    {
        public string Mode { get; set; }
        public int Position { get; set; }
        public int GeneratorWatts { get; set; }

        public Rover(int position)
        {
            Position = position;
            Mode = "NORMAL";
            GeneratorWatts = 110;
        }
        public void RecieveMessage(Message message)
        {
            Exception lowPower = new Exception("Rover cannot move in LOW_POWER mode");
            foreach(Command command in message.Commands)
            {
                if(command.CommandType == "MOVE")
                {
                    if (Mode == "NORMAL") 
                    {
                        Position = command.NewPostion; 
                    }
                    else
                    {
                        
                        //throw new Exception("Rover cannot move in LOW_POWER mode");                        
                        Console.WriteLine("Rover cannot move in LOW_POWER mode.");
                    }
                }
                else if(command.CommandType == "MODE_CHANGE")
                {
                    Mode = command.NewMode;
                }
                else
                {
                    //throw new System.ArgumentException("Please input a valid command");
                    Console.WriteLine("Please input a valid command.");
                }
            }

        }
        


        public override string ToString()
        {
            return "Position: " + Position + " - Mode: " + Mode + " - GeneratorWatts: " + GeneratorWatts; 
        }

    }
}
