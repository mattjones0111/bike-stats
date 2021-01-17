# Bike Stats

A web application providing access to numbers of bike thefts reported in
selected cities/areas.

## Dependencies

1. [dotnet 5](https://dotnet.microsoft.com/download/dotnet/5.0)
2. [BikeWise API](https://www.bikewise.org/documentation/api_v2)

## Build

```dotnet build```

## Test

```dotnet test```

## Run

```dotnet run```

## Contributing

1. Make a PR!

## Notes on completing the assignment

1. I was unsure whether the requirement was to show statistics for all candidate
locations *at the same time* (in a table) or whether it was required one by one 
(selected by a dropdown). I took the decision to use a dropdown as it was simpler,
however I've left abstractions in place that will make it easy to change this.

2. I noticed while looking at the responses from the target API in Postman that
it returns a 'Total' header so that a client knows how many results are available
and thus how many pages exist for this query. As the requirement was only to
show the *number* of thefts, we only need get page 1 and get the Total header
value rather than page through all the results. Again, abstractions are in place
to allow this to be changed easily.

3. I extracted an Exception type for the Bikewise API but I have not specifically
caught it; if it's thrown during a request to the API, the user will simply be
bounced to the site-wide exception page.

## // TODO

1. Extract a value type for Location so it's not just a string.
