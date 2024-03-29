﻿namespace ClassLibrary.Interfaces;

public interface IUserInterface
{
    public bool Ansoeg(double beloeb, int varighed, double indtaegt, double udgifter);
    public bool FrigivLaan(double beloeb, int kontonummer);
    public IGodkendLaan _godkendLaan { get; set; }
    public IDisplay _display { get; set; }
}