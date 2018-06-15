An Asp.Net core API which uses Micro services to get the move data from TMDB database, and uses Repository pattern and unit of work design for saving some movies to SQL database. It includes login, register actions as well. A logged in user can perform some actions. https://sibeeshpassion.com

This is a Movie Web API applciation <b>M4Movie</b>

 - The project is built with Asp.Net Core 2.0 Web API
 - The project is configured with Swagger, so that the user can easily test the features by following the link http://localhost:50270/swagger/

<b>APIs</b>

The current version of API has two actions in it.

 - Get(string searchType = "popular")
    
    where searchType is a string and the filter, eg: - popular, upcoming, no_playing etc... 
 
 - Get(id) 
    
    where id is a movie id

 - Get() 
 
    Will give you all the watchlist movies

 - Delete([FromBody] Movie movie)
 
    Will delete a movie from watchlist

 - Add([FromBody] Movie movie)

    Add movie to watch list 
 
    
    
