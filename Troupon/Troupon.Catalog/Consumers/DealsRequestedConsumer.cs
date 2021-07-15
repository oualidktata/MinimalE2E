using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api_facade.Models;
using MassTransit;
using Troupon.Catalog.Extensions;
using Troupon.Events;

namespace Troupon.Catalog.Consumers
{
    public class DealsRequestedConsumer : IConsumer<DealsRequested>
    {
        public async Task Consume(
            ConsumeContext<DealsRequested> context)
        {
            Console.WriteLine("[Catalog - DealsRequested] Event received");
            await context.RespondAsync<DealsRequestedResult>(new DealsRequestedResult { Deals = GetDeals()});
        }
        
        private static List<Deal> GetDeals()
        {
            var deals = new List<Deal>
            {
                new Deal {Name = "Clinique Chiropratique St-Martin", Description = "Exam, adjustment, X-rays with report", Address = "315, boulevard Saint-Martin Ouest, Laval", CurrentPrice = 16, OriginalPrice = -1, Image = "https://img.grouponcdn.com/deal/6y1v8a1NmA2dhzCrjA8P/J6-2048x1229/v1/c349x211.webp"},
                new Deal {Name = "Lave-Auto Vieux-Longueuil", Description = "Supreme detailing package", Address = "494 Boulevard Sainte-Foy, Longueuil", CurrentPrice = 22, OriginalPrice = 50, Image = "https://img.grouponcdn.com/deal/nNAr9akJ7yMPB8Vmb7HK/GD-1500x900/v1/c349x211.webp"},
                new Deal {Name = "Centre de Mécanique Écono", Description = "1 filter and mineral oil change package", Address = "2740, chemin du Lac, Longueuil", CurrentPrice = 25, OriginalPrice = 39, Image = "https://img.grouponcdn.com/deal/2ySZ4ZmgrhyVQndmpBQ8Cg1qSb8t/2y-1000x600/v1/c349x211.webp"},
                new Deal {Name = "MediSue Esthétique", Description = "One cryolipolysis treatment", Address = "347, rue Fleury Ouest, Montréal", CurrentPrice = 99, OriginalPrice = 400, Image = "https://img.grouponcdn.com/deal/3XSfomsjLqwoJhvkiymqSHP6u7HE/3X-700x420/v1/c349x211.webp"},
                new Deal {Name = "Centre Chiropratique de la Santé", Description = "Chiropractic care package", Address = "525, rue Fleury E, Montréal", CurrentPrice = 20, OriginalPrice = 227, Image = "https://img.grouponcdn.com/deal/LAJYmKkpXve9GpWHtuT/L6-2048x1229/v1/c349x211.webp"},
                new Deal {Name = "Café Déco Céramique", Description = "One Day of Ceramic Painting for Two People", Address = "289 Boulevard du Curé-Labelle, Laval", CurrentPrice = 9, OriginalPrice = 20, Image = "https://img.grouponcdn.com/deal/2dfxxX1nguyrP6LoQW2iiCeQfT3C/2d-960x576/v1/c349x211.webp"},
                new Deal {Name = "Centre Visuel Jean-Talon", Description = "Glasses and Sunglasses", Address = "420, rue Jean-Talon Est, Montréal", CurrentPrice = 22, OriginalPrice = 250, Image = "https://img.grouponcdn.com/deal/oZNiJbcMSty7Hk6UQAqEp6/main-700x420/v1/c349x211.webp"},
                new Deal {Name = "Lave Auto Marien", Description = "VIP Wash", Address = "11425, rue Victoria, Montréal-Est", CurrentPrice = 20, OriginalPrice = 65, Image = "https://img.grouponcdn.com/deal/uH4KpScT9wThvDUqgbZoZj2M6it/uH-1500x900/v1/c349x211.webp"},
                new Deal {Name = "Clinique yuanQi Massage & Acupuncture", Description = "60-minute Swedish massage for 1 person", Address = "8500 Boulevard Taschereau Unit 3, Brossard", CurrentPrice = 38, OriginalPrice = 70, Image = "https://img.grouponcdn.com/iam/2xwJxTZchkGuTkhHxy4jTCTyFGob/2x-2048x1229/v1/c349x211.webp"},
                new Deal {Name = "Intercoupe", Description = "Wash, cut and set package", Address = "5850, boulevard Décarie, Montréal", CurrentPrice = 19, OriginalPrice = 75, Image = "https://img.grouponcdn.com/iam/79gzninwxECohqMXFMFo9RCmbh8/79-2048x1229/v1/c349x211.webp"},
                new Deal {Name = "Dermka Clinik", Description = "One specialized anti-aging skin treatment", Address = "3534 Boulevard Dagenais Ouest, Laval", CurrentPrice = 49, OriginalPrice = 185, Image = "https://img.grouponcdn.com/deal/mSKfHRxaoBPbLStwVknE/8h-700x420/v1/c349x211.webp"},
                new Deal {Name = "Ongles à la française", Description = "Manicure and pedicure for natural nails", Address = "4593, rue Saint-Denis, Montréal", CurrentPrice = 21, OriginalPrice = 45, Image = "https://img.grouponcdn.com/deal/2QESyj6uoF5JPj9Gks91Cc8LD8yW/2Q-2048x1229/v1/c349x211.webp"},
            };
            
            deals.Shuffle();

            return deals;
        }
    }
}
