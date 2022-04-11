//Instanciamos el DbContext

using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();

  await MultipleEntitiesQuery();
//await AddNewDirectorWithVideo();
//await AddNewActorWithVideo();
//await AddNewStreamerWithVideoId();
//await AddNewStreamerWithVideo();
//await TrackingAndNotTracking();
//await QueryLinq();
//await QueryMethods();
//await QueryFilter();

Console.WriteLine("Presiona cualquier tecla para termonar el programa");
Console.ReadKey();

async Task MultipleEntitiesQuery()
{
    //var videoWithActores = await dbContext!.Videos!.Include(q => q.Actores).FirstOrDefaultAsync(q => q.Id == 1);

    //var actor = await dbContext!.Actor!.Select(q => q.Nombre).ToListAsync();

    var videoWithDirector = await dbContext!.Videos!
                            .Where(q=>q.Director != null)
                            .Include(q => q.Director)
                            .Select( q =>
                                new {

                                    Director_Nombre_Completo = $"{q.Director!.Nombre} {q.Director!.Apellido}",
                                    Movie = q.Nombre
                                }                                
                              )
                            .ToListAsync();

    foreach (var pelicula in videoWithDirector)
    {
        Console.WriteLine($"{pelicula.Movie} - {pelicula.Director_Nombre_Completo}");
    }
}

async Task AddNewDirectorWithVideo()
{
    var director = new Director
    {
        Nombre = "Lorenzo",
        Apellido = "Basteri",
        VideoId = 1
    };

    await dbContext.AddAsync(director);
    await dbContext.SaveChangesAsync();
}

async Task AddNewActorWithVideo()
{
    var actor = new Actor
    {
        Nombre = "Brad",
        Apellido = "Pit"
    };

    await dbContext.AddAsync(actor);
    await dbContext.SaveChangesAsync();

    var videoActor = new VideoActor
    {
        ActorId = actor.Id,
        VideoId = 1
    };

    await dbContext.AddAsync(videoActor);
    await dbContext.SaveChangesAsync();
}

async Task AddNewStreamerWithVideoId()
{
    var batmanForever = new Video
    {
        Nombre = "Batman Forever",
        StreamerId = 4
    };

    await dbContext.AddAsync(batmanForever);
    await dbContext.SaveChangesAsync();
}

async Task AddNewStreamerWithVideo()
{
    var pantaya = new Streamer
    {
        Nombre = "Pantaya"
    };

    var hungerGames = new Video
    {
        Nombre = "Hunger Games",
        Streamer = pantaya
    };

    await dbContext.AddAsync(hungerGames);
    await dbContext.SaveChangesAsync();
}

async Task TrackingAndNotTracking()
{
    var streamerWithTracking = await dbContext.Streamers!.FirstOrDefaultAsync(x => x.Id == 1); //si actualiza
    var streamerWithNoTracking = await dbContext.Streamers!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 2); //no actualiza

    streamerWithTracking!.Nombre = "Netflix Super";
    streamerWithNoTracking!.Nombre = "Amazon Plus";

    await dbContext.SaveChangesAsync();
}

async Task QueryLinq()
{
    Console.WriteLine("Ingrese el servicio de streaming");
    var streamerNombre = Console.ReadLine();
    var streamers = await (from i in dbContext.Streamers
                           where EF.Functions.Like(i.Nombre!,$"%{streamerNombre}%")
                           select i).ToListAsync(); //records tabla Streamers.

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}

async Task QueryMethods()
{
    var streamer  = dbContext.Streamers!;
    var firstAsync = await streamer.Where(y => y.Nombre!.Contains("a")).FirstAsync();
    var firstOrDefaultAsync = await streamer.Where(y => y.Nombre!.Contains("a")).FirstOrDefaultAsync();
    var firstOrDefaul_v2 = await streamer.FirstOrDefaultAsync(y => y.Nombre!.Contains("a"));

    var singleAsync = await streamer.Where(y => y.Id == 1).SingleAsync(); // muestra 1 solo resultado.
    var singleOrDefaultAsync = await streamer.Where(y => y.Id == 1).SingleOrDefaultAsync(); // devuelve valor o nulo, no genera excepcion

    var resultado = await streamer.FindAsync(1);

}

async Task QueryFilter()
{
    Console.WriteLine($"Ingrese una compañia de streaming");
    var streamingNombre = Console.ReadLine();
    var streamers = await dbContext!.Streamers!.Where(x => x.Nombre!.Equals(streamingNombre)).ToListAsync();
    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }

    //var streamerParticualResults = await dbContext.Streamers!.Where(x => x.Nombre!.Contains(streamingNombre!)).ToListAsync();
    var streamerParticualResults = await dbContext.Streamers!.Where(x => EF.Functions.Like(x.Nombre!,$"%{streamingNombre}%")).ToListAsync();
    foreach (var streamer in streamerParticualResults)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}

/* Agrega elementos al Streamers y agrega peliculas segun el Streamer seleccionado.
Streamer streamer = new()
{
    Nombre = "Amazon Prime",
    Url = "https://www.amazonprime.com"
};

dbContext!.Streamers!.Add(streamer);
await dbContext.SaveChangesAsync();

var movies = new List<Video>
{
    new Video {
        Nombre = "Mad Max",
        StreamerId = streamer.Id,
    },
    new Video {
        Nombre = "Batman",
        StreamerId = streamer.Id,
    },
    new Video {
        Nombre = "Crepusculo",
        StreamerId = streamer.Id,
    },
    new Video {
        Nombre = "Citizen Kane",
        StreamerId = streamer.Id,
    },
};

await dbContext.AddRangeAsync(movies);
await dbContext.SaveChangesAsync();
*/