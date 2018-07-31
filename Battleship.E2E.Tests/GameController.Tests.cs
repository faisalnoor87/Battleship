﻿using Battleship.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Battleship.E2E.Tests
{
    [TestClass]
    public class GameControllerTests
    {
        private static HttpClient _client;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            _client = new HttpClient { BaseAddress = new Uri("http://localhost/battleship/") };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [TestMethod]
        public void Setup()
        {            
            Setup(new Commands.SetupCommand
            {
                Ships = new[]
                {
                    "ship-p1-one 1,1 2 R",
                    "ship-p1-two 2,9 2 B"
                }
            });
           

            // Should use xunit or nunit for setup data
            var commands = new[]
            {
                new
                {
                    HitCommand = new Commands.HitCommand {X = 0, Y = 0},
                    Expected = new {Result = HitResult.Miss, Finished = false}
                },
                new
                {
                    HitCommand = new Commands.HitCommand { X = 1, Y = 1},
                    Expected = new {Result = HitResult.Hit, Finished = false}
                },
                new
                {
                    HitCommand = new Commands.HitCommand { X = 1, Y = 2},
                    Expected = new {Result = HitResult.Sink, Finished = false}
                },
                new
                {
                    HitCommand = new Commands.HitCommand { X = 2, Y = 9},
                    Expected = new {Result = HitResult.Hit, Finished = false}
                },
                new
                {
                    HitCommand = new Commands.HitCommand { X = 3, Y = 9},
                    Expected = new {Result = HitResult.Sink, Finished = true}
                }

            };

            Array.ForEach(commands, e =>
            {
                var status = Hit(e.HitCommand);
                Assert.AreEqual(e.Expected.Result, status.Result);
                Assert.AreEqual(e.Expected.Finished, status.Finished);
            });
        }

        private static Board.MissileStatus Hit(Commands.HitCommand hitCommand)
        {
            var response = _client.PutAsJsonAsync("api/hit", hitCommand).Result;
            var result = JsonConvert.DeserializeObject<Board.MissileStatus>(response.Content.ReadAsStringAsync().Result);
            return result;
        }

        private static void Setup(Commands.SetupCommand setupCommand)
        {
            var response = _client.PostAsJsonAsync("api/setup", setupCommand).Result;
            response.EnsureSuccessStatusCode();
        }
    }
}
