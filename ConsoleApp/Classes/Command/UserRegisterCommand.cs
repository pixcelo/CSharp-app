﻿namespace ConsoleApp.Classes.Command
{
    public class UserRegisterCommand
    {
        public UserRegisterCommand(string name)
        {
            Name = name;            
        }

        public string Name { get; }
    }
}
