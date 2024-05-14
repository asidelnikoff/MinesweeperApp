﻿namespace MinesweeperApp.Models;

public class RateLimitOptions
{
    public const string RateLimit = "RateLimit";
    public int PermitLimit { get; set; } = 100;
    public int Window { get; set; } = 10;
    public int QueueLimit { get; set; } = 2;
}
