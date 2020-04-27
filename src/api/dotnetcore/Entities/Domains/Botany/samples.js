// samples: https://odells.typepad.com/blog/corn-growth-stages.html

var taxonAttributes = [
    {
        taxon: 'Angiosperms',
        lifeCycles: {
            seed: {
                order: 0,
                attributes: {
                    'fire-resistance': 50,
                    'soil-moisture': 70
                }
            },
            sprout: {
                order: 1,
                attributes: {
                    'fire-resistance': 10
                }
            },
            flowering: {
                order: 1,
                attributes: {
                    'fire-resistance': 20
                }
            },
        }
    },
    //those characteristics would be inherited / suppresed on cultivar or any other taxon rank
    {
        taxon: 'Crotalaria Juncea',
        'flora-associations': [
            {
                taxon: { type: 'family', name: 'conifers' },
                interaction: 'x'
            }
        ],
        'fauna-associations': [
            {
                taxon: { type: 'species', name: 'dragonfly' },
            },
            {
                taxon: { type: 'species', name: 'bee' },
                interaction: { type: 'polinization' }
            },
            {
                taxon: { type: 'genus', name: 'Rhizobium' },
                interaction: { type: 'rhizo', outputs: 'nitrogen availability++' }
            },
        ],
        lifeCycles: {
            seed: {
                order: 0,
                attributes: {
                    'fire-resistance': 90,
                    PH: { min: 5, max: 8}
                }
            },
            sprout: {
                order: 1,
                attributes: {
                    'fire-resistance': 15
                }
            },
            flowering: {
                order: 1,
                attributes: {
                    'fire-resistance': 30,
                    'forest-level': 'arbust'
                }
            },
        }
    }
];
