# Todo Exercise

This exercise provides candidates the opportunity to demonstrate a working knowledge of the following subjects:
- Angular 2+ (currently 13)
- ASP.NET WebApi (currently .NET 6)
- Unit testing
- Git

# Getting started

## Get a copy of the code
- Create a new repository at github.com
  - Make it public
  - Don't initialize it with a README, .gitignore, or license
- Clone this repository to your local machine
  - `git clone https://github.com/mortware/todo`
  - Switch to the repo directory `cd todo`
- Replace the origin with your own repository.
  - `git remote rm origin`
  - `git remote add origin https://github.com/[your-account]/[your-repo].git`
- Push the local repository to your repository on github.
  - `git push --set-upstream origin main`

When you have finished the exercise, please provide a link to the new repository.

### To run the back-end WebAPI
`cd .\api\src\Todo.Api\`

`dotnet run`

### To run the front-end web application
`cd .\web`

`npm install`

`ng serve`

# Tasks

### Bug fixes
1. Bug fix: 'Prevent double submission'
   > On slow connections, it's possible to multi-click the Submit button while a request is in progress. Please fix this by disabling the button when the request is in progress.

### New features
1. Add new feature: 'Mark as completed'
   > As a user, I want the ability to mark my todo items as completed.
   1. Implement UI and API call to set an item as `completed`
   2. The completed date must be displayed in the UI, if the item is visible
2. Add new feature: 'Show completed items' 
   > As a user, I don't want to see my completed items unless I have chosen to do so.
   1. Implement UI and API call to show/hide completed items in the list view
   2. Completed items should not be shown by default

### Feature changes
1. Disable submit button if there is no text in 'Create new item'
1. Feature change: 'Item ordering'
   > As a user, I want to see the most recently created items at the top
2. Feature change: 'Make all items uppercase'
   > As a user, I want my item text to automatically convert to uppercase after I've submitted it

### Technical tasks
1. Add unit tests for new API logic
2. Remove any redundant code


### Bonus tasks
1. Add unit tests for angular components/services

# Further information

## Todo Item Example
```json
{
   "id": "504c4345-121b-4523-865d-ce76416c16fd",
   "text": "Feed the cat",
   "created": "2022-03-23T16:41:29.9809001Z",
   "completed": "2022-03-23T20:01:10.1265001Z"
}
```
