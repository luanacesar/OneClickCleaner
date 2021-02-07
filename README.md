# Online Web Application / Deployed: 
## https://oneclickcleanercomp231.azurewebsites.net/
## Unit test = Go to branch called "test"
## Diagram / documentation = Go to branch called "docs" 

## Download the code on Branch 15 and run the database with the code below:

add-migration -Context ApplicationDbContext initial
add-migration -Context AppIdentityDbContext Initial
update-database -Context AppIdentityDbContext
