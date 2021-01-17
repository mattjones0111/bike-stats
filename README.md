# Bike Stats

A web application providing access to numbers of bike thefts reported in
selected cities/areas.

## Build

```dotnet build```

## Test

```dotnet test```

## Notes on the assignment

1. I was unsure whether the requirement was to show statistics for all candidate
locations *at the same time* (in a table) or whether it was required one by one 
(selected by a dropdown). I took the decision to use a dropdown, however I've left abstractions in place that will make it easy to change this.

2. I noticed while looking at the responses from the target API in Postman that
it provides a 'Total' header so that a client knows how many results are available,
and thus how many pages exist for this query. As the requirement was only to
show the *number* of thefts, I only need call for page 1 and get the Total header
value, rather than page through all the results.

3. I extracted an Exception type for the Bikewise API but I have not specifically
caught it; if it's thrown during a request to the API, the user will simply be
bounced to the site-wide exception page.
