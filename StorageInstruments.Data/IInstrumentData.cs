﻿using StorageInstruments.Model;
using System.Collections.Generic;
using System.Linq;

namespace StorageInstruments.Data
{
    public interface IInstrumentData
    {
        IEnumerable<Instrument> GetInstrumentsByName(string name);
    }

    public class InMemoryInstruments : IInstrumentData
    {
        List<Instrument> instruments;
        public InMemoryInstruments()
        {
            instruments = new List<Instrument>()
            {
                new Instrument {Id = 1, Location = LocationType.Home, Name="Alhambra", owner="Potato", Type = InstrumentType.Chords},
                new Instrument {Id = 2, Location = LocationType.Home, Name="SAD", owner="FFFF", Type = InstrumentType.Percurssion},
                new Instrument {Id = 3, Location = LocationType.WithOwner, Name="gggg", owner="21df", Type = InstrumentType.Tools}
            };
        }

        public IEnumerable<Instrument> GetInstrumentsByName(string name)
        {
            return from r in instruments
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Id
                   select r;
        }
    }
}
