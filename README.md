<p align="center">
  <img src="https://img.icons8.com/?size=512&id=55494&format=png" width="20%" alt="LIBRARYAPI-logo">
</p>
<p align="center">
    <h1 align="center">LIBRARY API</h1>
</p>
<p align="center">
    <em><code>❯ Library API</code></em>
</p>
<p align="center">
	<img src="https://img.shields.io/github/license/suaybdemir/LibraryAPI?style=flat&logo=opensourceinitiative&logoColor=white&color=f1f1f1" alt="license">
	<img src="https://img.shields.io/github/last-commit/suaybdemir/LibraryAPI?style=flat&logo=git&logoColor=white&color=f1f1f1" alt="last-commit">
	<img src="https://img.shields.io/github/languages/top/suaybdemir/LibraryAPI?style=flat&color=f1f1f1" alt="repo-top-language">
	<img src="https://img.shields.io/github/languages/count/suaybdemir/LibraryAPI?style=flat&color=f1f1f1" alt="repo-language-count">
</p>
<p align="center">
		<em>Built with .Net Core and technologies:</em>
</p>
<p align="center">
	<img src="https://img.shields.io/badge/JSON-000000.svg?style=flat&logo=JSON&logoColor=white" alt="JSON">
</p>

<br>

#####  Table of Contents

- [ Overview](#-overview)
- [ Features](#-features)
- [ Repository Structure](#-repository-structure)
- [ Modules](#-modules)
- [ Getting Started](#-getting-started)
    - [ Prerequisites](#-prerequisites)
    - [ Installation](#-installation)
    - [ Usage](#-usage)
    - [ Tests](#-tests)
- [ Project Roadmap](#-project-roadmap)
- [ Contributing](#-contributing)
- [ License](#-license)
- [ Acknowledgments](#-acknowledgments)

---

##  Overview

<code>❯ Had built api in order to serve services for library management apps.</code>

---

##  Features

<code>❯ SOON...</code>

---

##  Repository Structure

```sh
└── LibraryAPI/
    ├── LibraryAPI  
    │   ├── LibraryAPI
    │   │   ├── Controllers
    │   │   │   └── Concrete
    │   │   │       ├── AuthenticationController.cs
    │   │   │       ├── AuthorRepresentativeBooksController.cs
    │   │   │       ├── AuthorsController.cs
    │   │   │       ├── BookLanguagesController.cs
    │   │   │       ├── BooksController.cs
    │   │   │       ├── CategoriesController.cs
    │   │   │       ├── DisLikeController.cs
    │   │   │       ├── DonatorsController.cs
    │   │   │       ├── EmployeesController.cs
    │   │   │       ├── FavouritesController.cs
    │   │   │       ├── LanguagesController.cs
    │   │   │       ├── LibrariesController.cs
    │   │   │       ├── LibraryRepresentativeBookStocksController.cs
    │   │   │       ├── LikesController.cs
    │   │   │       ├── LocationsController.cs
    │   │   │       ├── MembersController.cs
    │   │   │       ├── PublisherEMailsController.cs
    │   │   │       ├── PublisherPhonesController.cs
    │   │   │       ├── PublisherRepresentativeBooksController.cs
    │   │   │       ├── PublishersController.cs
    │   │   │       ├── RepresentativeBookCategoriesSubCategoriesController.cs
    │   │   │       ├── RepresentativeBooksController.cs
    │   │   │       ├── RepresentativeBooksRatingController.cs
    │   │   │       ├── RolesController.cs
    │   │   │       ├── SubCategoriesController.cs
    │   │   │       └── TransactionsController.cs
    │   │   ├── Data
    │   │   │   └── ApplicationContext.cs
    │   │   ├── Models
    │   │   │   ├── Abstract
    │   │   │   │   ├── AbstractCategory.cs
    │   │   │   │   ├── AbstractLike.cs
    │   │   │   │   └── AbstractPerson.cs
    │   │   │   └── Concrete
    │   │   │       ├── ApplicationUser.cs
    │   │   │       ├── Author.cs
    │   │   │       ├── AuthorRepresentativeBook.cs
    │   │   │       ├── Book.cs
    │   │   │       ├── BookLanguage.cs
    │   │   │       ├── Category.cs
    │   │   │       ├── DisLike.cs
    │   │   │       ├── Donator.cs
    │   │   │       ├── Employee.cs
    │   │   │       ├── Favourite.cs
    │   │   │       ├── Language.cs
    │   │   │       ├── Library.cs
    │   │   │       ├── LibraryRepresentativeBookStock.cs
    │   │   │       ├── Like.cs
    │   │   │       ├── Location.cs
    │   │   │       ├── Member.cs
    │   │   │       ├── Publisher.cs
    │   │   │       ├── PublisherEMail.cs
    │   │   │       ├── PublisherPhone.cs
    │   │   │       ├── PublisherRepresentativeBook.cs
    │   │   │       ├── RepresentativeBook.cs
    │   │   │       ├── RepresentativeBookCategorySubCategory.cs
    │   │   │       ├── RepresentativeBookRating.cs
    │   │   │       ├── SubCategory.cs
    │   │   │       └── Transaction.cs
    │   │   ├── Program.cs
    │   │   ├── Properties
                └── launchSettings.json
```

---

##  Modules


<details closed><summary>LibraryAPI</summary>

| File | Summary |
| --- | --- |
| [Program.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Program.cs) | <code>❯ MiddleWare</code> |

</details>


<details closed><summary>LibraryAPI.LibraryAPI.Properties</summary>

| File | Summary |
| --- | --- |
| [launchSettings.json](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Properties/launchSettings.json) | <code>❯ LaunchSettings</code> |

</details>


<details closed><summary>LibraryAPI.LibraryAPI.Data</summary>

| File | Summary |
| --- | --- |
| [ApplicationContext.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Data/ApplicationContext.cs) | <code>❯ Data Layer</code> |

</details>

<details closed><summary>LibraryAPI.LibraryAPI.Models.Concrete</summary>

| File | Summary |
| --- | --- |
| [PublisherPhone.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/PublisherPhone.cs) | <code>❯ PublisherPhone</code> |
| [Publisher.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Publisher.cs) | <code>❯ Publisher</code> |
| [Location.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Location.cs) | <code>❯ Location</code> |
| [DisLike.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/DisLike.cs) | <code>❯ DisLike</code> |
| [Member.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Member.cs) | <code>❯ Member</code> |
| [Book.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Book.cs) | <code>❯ Book</code> |
| [Favourite.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Favourite.cs) | <code>❯ Favourite</code> |
| [RepresentativeBookRating.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/RepresentativeBookRating.cs) | <code>❯ RepresentativeBookRating</code> |
| [Like.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Like.cs) | <code>❯ Like</code> |
| [Donator.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Donator.cs) | <code>❯ Donator</code> |
| [Transaction.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Transaction.cs) | <code>❯ Transaction</code> |
| [PublisherEMail.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/PublisherEMail.cs) | <code>❯ PublisherEMail</code> |
| [BookLanguage.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/BookLanguage.cs) | <code>❯ BookLanguage</code> |
| [LibraryRepresentativeBookStock.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/LibraryRepresentativeBookStock.cs) | <code>❯ LibraryRepresentativeBookStock</code> |
| [ApplicationUser.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/ApplicationUser.cs) | <code>❯ ApplicationUser</code> |
| [Category.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Category.cs) | <code>❯ Category</code> |
| [AuthorRepresentativeBook.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/AuthorRepresentativeBook.cs) | <code>❯ AuthorRepresentativeBook</code> |
| [RepresentativeBookCategorySubCategory.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/RepresentativeBookCategorySubCategory.cs) | <code>❯ RepresentativeBookCategorySubCategory</code> |
| [RepresentativeBook.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/RepresentativeBook.cs) | <code>❯ RepresentativeBook</code> |
| [SubCategory.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/SubCategory.cs) | <code>❯ SubCategory</code> |
| [Employee.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Employee.cs) | <code>❯ Employee</code> |
| [Language.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Language.cs) | <code>❯ Language</code> |
| [Author.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Author.cs) | <code>❯ Author</code> |
| [PublisherRepresentativeBook.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/PublisherRepresentativeBook.cs) | <code>❯ PublisherRepresentativeBook</code> |

</details>

<details closed><summary>LibraryAPI.LibraryAPI.Models.Abstract</summary>

| File | Summary |
| --- | --- |
| [AbstractLike.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Abstract/AbstractLike.cs) | <code>❯ AbstractLike</code> |
| [AbstractPerson.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Abstract/AbstractPerson.cs) | <code>❯ AbstractPerson</code> |
| [AbstractCategory.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Abstract/AbstractCategory.cs) | <code>❯ AbstractCategory</code> |

</details>

<details closed><summary>LibraryAPI.LibraryAPI.Controllers.Concrete</summary>

| File | Summary |
| --- | --- |
| [PublisherRepresentativeBooksController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/PublisherRepresentativeBooksController.cs) | <code>❯ PublisherRepresentativeBooksController</code> |
| [AuthorRepresentativeBooksController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/AuthorRepresentativeBooksController.cs) | <code>❯ AuthorRepresentativeBooksController</code> |
| [RepresentativeBookCategoriesSubCategoriesController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/RepresentativeBookCategoriesSubCategoriesController.cs) | <code>❯ RepresentativeBookCategoriesSubCategoriesController</code> |
| [AuthorsController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/AuthorsController.cs) | <code>❯ AuthorsController</code> |
| [TransactionsController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/TransactionsController.cs) | <code>❯ TransactionsController</code> |
| [CategoriesController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/CategoriesController.cs) | <code>❯ CategoriesController</code> |
| [FavouritesController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/FavouritesController.cs) | <code>❯ FavouritesController</code> |
| [RepresentativeBooksController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/RepresentativeBooksController.cs) | <code>❯ RepresentativeBooksController</code> |
| [RepresentativeBooksRatingController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/RepresentativeBooksRatingController.cs) | <code>❯ RepresentativeBooksRatingController</code> |
| [DisLikeController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/DisLikeController.cs) | <code>❯ DisLikeController</code> |
| [LibrariesController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/LibrariesController.cs) | <code>❯ LibrariesController</code> |
| [LanguagesController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/LanguagesController.cs) | <code>❯ LanguagesController</code> |
| [BookLanguagesController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/BookLanguagesController.cs) | <code>❯ BookLanguagesController</code> |
| [DonatorsController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/DonatorsController.cs) | <code>❯ DonatorsController</code> |
| [MembersController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/MembersController.cs) | <code>❯ MembersController</code> |
| [LocationsController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/LocationsController.cs) | <code>❯ LocationsController</code> |
| [AuthenticationController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/AuthenticationController.cs) | <code>❯ AuthenticationController</code> |
| [LikesController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/LikesController.cs) | <code>❯ LikesController</code> |
| [LibraryRepresentativeBookStocksController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/LibraryRepresentativeBookStocksController.cs) | <code>❯ LibraryRepresentativeBookStocksController</code> |
| [PublishersController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/PublishersController.cs) | <code>❯ PublishersController</code> |
| [EmployeesController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/EmployeesController.cs) | <code>❯ EmployeesController</code> |
| [PublisherEMailsController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/PublisherEMailsController.cs) | <code>❯ PublisherEMailsController</code> |
| [BooksController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/BooksController.cs) | <code>❯ BooksController</code> |
| [SubCategoriesController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/SubCategoriesController.cs) | <code>❯ SubCategoriesController</code> |
| [RolesController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/RolesController.cs) | <code>❯ RolesController</code> |
| [PublisherPhonesController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/PublisherPhonesController.cs) | <code>❯ PublisherPhonesController</code> |

</details>

---

##  Getting Started

###  Prerequisites

**.Net Core**: `6.0`

###  Installation

Build the project from source:

1. Clone the LibraryAPI repository:
```sh
❯ git clone https://github.com/suaybdemir/LibraryAPI
```

2. Navigate to the project directory:
```sh
❯ cd LibraryAPI
```

3. Install the required dependencies:
```sh
❯ dotnet build
```

###  Usage

To run the project, execute the following command:

```sh
❯ dotnet run
```

###  Tests

Execute the test suite using the following command:

```sh
❯ dotnet test
```

---

##  Project Roadmap

- [X] **`Task 1`**: <strike>Implement feature one.</strike>
- [ ] **`Task 2`**: Implement feature two.
- [ ] **`Task 3`**: Implement feature three.

---

##  Contributing

Contributions are welcome! Here are several ways you can contribute:

- **[Report Issues](https://github.com/suaybdemir/LibraryAPI/issues)**: Submit bugs found or log feature requests for the `LibraryAPI` project.
- **[Submit Pull Requests](https://github.com/suaybdemir/LibraryAPI/blob/main/CONTRIBUTING.md)**: Review open PRs, and submit your own PRs.
- **[Join the Discussions](https://github.com/suaybdemir/LibraryAPI/discussions)**: Share your insights, provide feedback, or ask questions.

<details closed>
<summary>Contributing Guidelines</summary>

1. **Fork the Repository**: Start by forking the project repository to your github account.
2. **Clone Locally**: Clone the forked repository to your local machine using a git client.
   ```sh
   git clone https://github.com/suaybdemir/LibraryAPI
   ```
3. **Create a New Branch**: Always work on a new branch, giving it a descriptive name.
   ```sh
   git checkout -b new-feature-x
   ```
4. **Make Your Changes**: Develop and test your changes locally.
5. **Commit Your Changes**: Commit with a clear message describing your updates.
   ```sh
   git commit -m 'Implemented new feature x.'
   ```
6. **Push to github**: Push the changes to your forked repository.
   ```sh
   git push origin new-feature-x
   ```
7. **Submit a Pull Request**: Create a PR against the original project repository. Clearly describe the changes and their motivations.
8. **Review**: Once your PR is reviewed and approved, it will be merged into the main branch. Congratulations on your contribution!
</details>

<details closed>
<summary>Contributor Graph</summary>
<br>
<p align="left">
   <a href="https://github.com{/suaybdemir/LibraryAPI/}graphs/contributors">
      <img src="https://contrib.rocks/image?repo=suaybdemir/LibraryAPI">
   </a>
</p>
</details>

---

##  License

This project is protected under the [SELECT-A-LICENSE](https://choosealicense.com/licenses) License. For more details, refer to the [LICENSE](https://choosealicense.com/licenses/) file.

---

##  Acknowledgments

- List any resources, contributors, inspiration, etc. here.

---
