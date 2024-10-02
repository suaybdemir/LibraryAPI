<p align="center">
  <img src="https://img.icons8.com/?size=512&id=55494&format=png" width="20%" alt="LIBRARYAPI-logo">
</p>
<p align="center">
    <h1 align="center">LIBRARYAPI</h1>
</p>
<p align="center">
    <em><code>❯ REPLACE-ME</code></em>
</p>
<p align="center">
	<img src="https://img.shields.io/github/license/suaybdemir/LibraryAPI?style=flat&logo=opensourceinitiative&logoColor=white&color=f1f1f1" alt="license">
	<img src="https://img.shields.io/github/last-commit/suaybdemir/LibraryAPI?style=flat&logo=git&logoColor=white&color=f1f1f1" alt="last-commit">
	<img src="https://img.shields.io/github/languages/top/suaybdemir/LibraryAPI?style=flat&color=f1f1f1" alt="repo-top-language">
	<img src="https://img.shields.io/github/languages/count/suaybdemir/LibraryAPI?style=flat&color=f1f1f1" alt="repo-language-count">
</p>
<p align="center">
		<em>Built with the tools and technologies:</em>
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

<code>❯ REPLACE-ME</code>

---

##  Features

<code>❯ REPLACE-ME</code>

---

##  Repository Structure

```sh
└── LibraryAPI/
    ├── LibraryAPI
    │   ├── .vs
    │   │   ├── LibraryAPI
    │   │   │   ├── DesignTimeBuild
    │   │   │   │   └── .dtbcache.v2
    │   │   │   ├── FileContentIndex
    │   │   │   │   ├── 86e31518-615e-4d86-8835-0b7b44610b11.vsidx
    │   │   │   │   ├── 8886e2b9-0f04-4597-940f-a7c43d730a1b.vsidx
    │   │   │   │   ├── a1735f14-85c3-4ad1-ab73-fbf2a3dc0774.vsidx
    │   │   │   │   ├── f0ed9773-9172-4a1a-a5e2-4b2aacb9d974.vsidx
    │   │   │   │   └── f34a3ab4-736f-40e2-b06b-348f4f458a7f.vsidx
    │   │   │   ├── config
    │   │   │   │   └── applicationhost.config
    │   │   │   └── v17
    │   │   │       ├── .futdcache.v2
    │   │   │       ├── .suo
    │   │   │       └── DocumentLayout.json
    │   │   └── ProjectEvaluation
    │   │       ├── libraryapi.metadata.v8.bin
    │   │       ├── libraryapi.projects.v8.bin
    │   │       └── libraryapi.strings.v8.bin
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
    │   │   ├── LibraryAPI.csproj
    │   │   ├── LibraryAPI.csproj.user
    │   │   ├── Migrations
    │   │   │   ├── 20240809124059_init.Designer.cs
    │   │   │   ├── 20240809124059_init.cs
    │   │   │   └── ApplicationContextModelSnapshot.cs
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
    │   │   │   └── launchSettings.json
    │   │   ├── appsettings.json
    │   │   └── obj
    │   │       ├── Debug
    │   │       │   └── net6.0
    │   │       ├── LibraryAPI.csproj.EntityFrameworkCore.targets
    │   │       ├── LibraryAPI.csproj.nuget.dgspec.json
    │   │       ├── LibraryAPI.csproj.nuget.g.props
    │   │       ├── LibraryAPI.csproj.nuget.g.targets
    │   │       └── project.assets.json
    │   └── LibraryAPI.sln
    └── README.md
```

---

##  Modules

<details closed><summary>LibraryAPI</summary>

| File | Summary |
| --- | --- |
| [LibraryAPI.sln](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI.sln) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>LibraryAPI.LibraryAPI</summary>

| File | Summary |
| --- | --- |
| [appsettings.json](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/appsettings.json) | <code>❯ REPLACE-ME</code> |
| [LibraryAPI.csproj](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/LibraryAPI.csproj) | <code>❯ REPLACE-ME</code> |
| [Program.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Program.cs) | <code>❯ REPLACE-ME</code> |
| [LibraryAPI.csproj.user](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/LibraryAPI.csproj.user) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>LibraryAPI.LibraryAPI.obj</summary>

| File | Summary |
| --- | --- |
| [LibraryAPI.csproj.nuget.dgspec.json](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/obj/LibraryAPI.csproj.nuget.dgspec.json) | <code>❯ REPLACE-ME</code> |
| [LibraryAPI.csproj.nuget.g.props](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/obj/LibraryAPI.csproj.nuget.g.props) | <code>❯ REPLACE-ME</code> |
| [LibraryAPI.csproj.nuget.g.targets](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/obj/LibraryAPI.csproj.nuget.g.targets) | <code>❯ REPLACE-ME</code> |
| [project.assets.json](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/obj/project.assets.json) | <code>❯ REPLACE-ME</code> |
| [LibraryAPI.csproj.EntityFrameworkCore.targets](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/obj/LibraryAPI.csproj.EntityFrameworkCore.targets) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>LibraryAPI.LibraryAPI.obj.Debug.net6.0</summary>

| File | Summary |
| --- | --- |
| [LibraryAPI.csproj.FileListAbsolute.txt](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/obj/Debug/net6.0/LibraryAPI.csproj.FileListAbsolute.txt) | <code>❯ REPLACE-ME</code> |
| [LibraryAPI.GlobalUsings.g.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/obj/Debug/net6.0/LibraryAPI.GlobalUsings.g.cs) | <code>❯ REPLACE-ME</code> |
| [.NETCoreApp,Version=v6.0.AssemblyAttributes.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/obj/Debug/net6.0/.NETCoreApp,Version=v6.0.AssemblyAttributes.cs) | <code>❯ REPLACE-ME</code> |
| [LibraryAPI.csproj.BuildWithSkipAnalyzers](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/obj/Debug/net6.0/LibraryAPI.csproj.BuildWithSkipAnalyzers) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>LibraryAPI.LibraryAPI.Properties</summary>

| File | Summary |
| --- | --- |
| [launchSettings.json](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Properties/launchSettings.json) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>LibraryAPI.LibraryAPI.Migrations</summary>

| File | Summary |
| --- | --- |
| [20240809124059_init.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Migrations/20240809124059_init.cs) | <code>❯ REPLACE-ME</code> |
| [20240809124059_init.Designer.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Migrations/20240809124059_init.Designer.cs) | <code>❯ REPLACE-ME</code> |
| [ApplicationContextModelSnapshot.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Migrations/ApplicationContextModelSnapshot.cs) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>LibraryAPI.LibraryAPI.Data</summary>

| File | Summary |
| --- | --- |
| [ApplicationContext.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Data/ApplicationContext.cs) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>LibraryAPI.LibraryAPI.Models.Concrete</summary>

| File | Summary |
| --- | --- |
| [PublisherPhone.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/PublisherPhone.cs) | <code>❯ REPLACE-ME</code> |
| [Publisher.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Publisher.cs) | <code>❯ REPLACE-ME</code> |
| [Location.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Location.cs) | <code>❯ REPLACE-ME</code> |
| [DisLike.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/DisLike.cs) | <code>❯ REPLACE-ME</code> |
| [Member.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Member.cs) | <code>❯ REPLACE-ME</code> |
| [Book.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Book.cs) | <code>❯ REPLACE-ME</code> |
| [Favourite.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Favourite.cs) | <code>❯ REPLACE-ME</code> |
| [RepresentativeBookRating.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/RepresentativeBookRating.cs) | <code>❯ REPLACE-ME</code> |
| [Like.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Like.cs) | <code>❯ REPLACE-ME</code> |
| [Donator.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Donator.cs) | <code>❯ REPLACE-ME</code> |
| [Transaction.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Transaction.cs) | <code>❯ REPLACE-ME</code> |
| [PublisherEMail.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/PublisherEMail.cs) | <code>❯ REPLACE-ME</code> |
| [BookLanguage.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/BookLanguage.cs) | <code>❯ REPLACE-ME</code> |
| [LibraryRepresentativeBookStock.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/LibraryRepresentativeBookStock.cs) | <code>❯ REPLACE-ME</code> |
| [ApplicationUser.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/ApplicationUser.cs) | <code>❯ REPLACE-ME</code> |
| [Library.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Library.cs) | <code>❯ REPLACE-ME</code> |
| [Category.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Category.cs) | <code>❯ REPLACE-ME</code> |
| [AuthorRepresentativeBook.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/AuthorRepresentativeBook.cs) | <code>❯ REPLACE-ME</code> |
| [RepresentativeBookCategorySubCategory.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/RepresentativeBookCategorySubCategory.cs) | <code>❯ REPLACE-ME</code> |
| [RepresentativeBook.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/RepresentativeBook.cs) | <code>❯ REPLACE-ME</code> |
| [SubCategory.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/SubCategory.cs) | <code>❯ REPLACE-ME</code> |
| [Employee.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Employee.cs) | <code>❯ REPLACE-ME</code> |
| [Language.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Language.cs) | <code>❯ REPLACE-ME</code> |
| [Author.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/Author.cs) | <code>❯ REPLACE-ME</code> |
| [PublisherRepresentativeBook.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Concrete/PublisherRepresentativeBook.cs) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>LibraryAPI.LibraryAPI.Models.Abstract</summary>

| File | Summary |
| --- | --- |
| [AbstractLike.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Abstract/AbstractLike.cs) | <code>❯ REPLACE-ME</code> |
| [AbstractPerson.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Abstract/AbstractPerson.cs) | <code>❯ REPLACE-ME</code> |
| [AbstractCategory.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Models/Abstract/AbstractCategory.cs) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>LibraryAPI.LibraryAPI.Controllers.Concrete</summary>

| File | Summary |
| --- | --- |
| [PublisherRepresentativeBooksController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/PublisherRepresentativeBooksController.cs) | <code>❯ REPLACE-ME</code> |
| [AuthorRepresentativeBooksController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/AuthorRepresentativeBooksController.cs) | <code>❯ REPLACE-ME</code> |
| [RepresentativeBookCategoriesSubCategoriesController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/RepresentativeBookCategoriesSubCategoriesController.cs) | <code>❯ REPLACE-ME</code> |
| [AuthorsController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/AuthorsController.cs) | <code>❯ REPLACE-ME</code> |
| [TransactionsController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/TransactionsController.cs) | <code>❯ REPLACE-ME</code> |
| [CategoriesController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/CategoriesController.cs) | <code>❯ REPLACE-ME</code> |
| [FavouritesController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/FavouritesController.cs) | <code>❯ REPLACE-ME</code> |
| [RepresentativeBooksController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/RepresentativeBooksController.cs) | <code>❯ REPLACE-ME</code> |
| [RepresentativeBooksRatingController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/RepresentativeBooksRatingController.cs) | <code>❯ REPLACE-ME</code> |
| [DisLikeController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/DisLikeController.cs) | <code>❯ REPLACE-ME</code> |
| [LibrariesController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/LibrariesController.cs) | <code>❯ REPLACE-ME</code> |
| [LanguagesController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/LanguagesController.cs) | <code>❯ REPLACE-ME</code> |
| [BookLanguagesController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/BookLanguagesController.cs) | <code>❯ REPLACE-ME</code> |
| [DonatorsController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/DonatorsController.cs) | <code>❯ REPLACE-ME</code> |
| [MembersController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/MembersController.cs) | <code>❯ REPLACE-ME</code> |
| [LocationsController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/LocationsController.cs) | <code>❯ REPLACE-ME</code> |
| [AuthenticationController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/AuthenticationController.cs) | <code>❯ REPLACE-ME</code> |
| [LikesController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/LikesController.cs) | <code>❯ REPLACE-ME</code> |
| [LibraryRepresentativeBookStocksController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/LibraryRepresentativeBookStocksController.cs) | <code>❯ REPLACE-ME</code> |
| [PublishersController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/PublishersController.cs) | <code>❯ REPLACE-ME</code> |
| [EmployeesController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/EmployeesController.cs) | <code>❯ REPLACE-ME</code> |
| [PublisherEMailsController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/PublisherEMailsController.cs) | <code>❯ REPLACE-ME</code> |
| [BooksController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/BooksController.cs) | <code>❯ REPLACE-ME</code> |
| [SubCategoriesController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/SubCategoriesController.cs) | <code>❯ REPLACE-ME</code> |
| [RolesController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/RolesController.cs) | <code>❯ REPLACE-ME</code> |
| [PublisherPhonesController.cs](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/LibraryAPI/Controllers/Concrete/PublisherPhonesController.cs) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>LibraryAPI..vs.LibraryAPI.FileContentIndex</summary>

| File | Summary |
| --- | --- |
| [8886e2b9-0f04-4597-940f-a7c43d730a1b.vsidx](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/.vs/LibraryAPI/FileContentIndex/8886e2b9-0f04-4597-940f-a7c43d730a1b.vsidx) | <code>❯ REPLACE-ME</code> |
| [f34a3ab4-736f-40e2-b06b-348f4f458a7f.vsidx](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/.vs/LibraryAPI/FileContentIndex/f34a3ab4-736f-40e2-b06b-348f4f458a7f.vsidx) | <code>❯ REPLACE-ME</code> |
| [86e31518-615e-4d86-8835-0b7b44610b11.vsidx](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/.vs/LibraryAPI/FileContentIndex/86e31518-615e-4d86-8835-0b7b44610b11.vsidx) | <code>❯ REPLACE-ME</code> |
| [f0ed9773-9172-4a1a-a5e2-4b2aacb9d974.vsidx](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/.vs/LibraryAPI/FileContentIndex/f0ed9773-9172-4a1a-a5e2-4b2aacb9d974.vsidx) | <code>❯ REPLACE-ME</code> |
| [a1735f14-85c3-4ad1-ab73-fbf2a3dc0774.vsidx](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/.vs/LibraryAPI/FileContentIndex/a1735f14-85c3-4ad1-ab73-fbf2a3dc0774.vsidx) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>LibraryAPI..vs.LibraryAPI.v17</summary>

| File | Summary |
| --- | --- |
| [DocumentLayout.json](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/.vs/LibraryAPI/v17/DocumentLayout.json) | <code>❯ REPLACE-ME</code> |
| [.futdcache.v2](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/.vs/LibraryAPI/v17/.futdcache.v2) | <code>❯ REPLACE-ME</code> |
| [.suo](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/.vs/LibraryAPI/v17/.suo) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>LibraryAPI..vs.LibraryAPI.DesignTimeBuild</summary>

| File | Summary |
| --- | --- |
| [.dtbcache.v2](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/.vs/LibraryAPI/DesignTimeBuild/.dtbcache.v2) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>LibraryAPI..vs.LibraryAPI.config</summary>

| File | Summary |
| --- | --- |
| [applicationhost.config](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/.vs/LibraryAPI/config/applicationhost.config) | <code>❯ REPLACE-ME</code> |

</details>

<details closed><summary>LibraryAPI..vs.ProjectEvaluation</summary>

| File | Summary |
| --- | --- |
| [libraryapi.projects.v8.bin](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/.vs/ProjectEvaluation/libraryapi.projects.v8.bin) | <code>❯ REPLACE-ME</code> |
| [libraryapi.metadata.v8.bin](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/.vs/ProjectEvaluation/libraryapi.metadata.v8.bin) | <code>❯ REPLACE-ME</code> |
| [libraryapi.strings.v8.bin](https://github.com/suaybdemir/LibraryAPI/blob/main/LibraryAPI/.vs/ProjectEvaluation/libraryapi.strings.v8.bin) | <code>❯ REPLACE-ME</code> |

</details>

---

##  Getting Started

###  Prerequisites

**CSharp**: `version x.y.z`

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
