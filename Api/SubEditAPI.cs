using MediaBrowser.Controller.Dto;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Entities.Movies;
using MediaBrowser.Controller.Library;
using MediaBrowser.Controller.Persistence;
using MediaBrowser.Model.IO;
using MediaBrowser.Model.Logging;
using MediaBrowser.Model.Querying;
using MediaBrowser.Model.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emby.SubEdit.Api
{
    class SubEditAPI : IService
    {
        [Route("/SubEditService/Search", "GET", Summary = "Search library for items with subtitles in a valid codec")]
        public class SubtitleSearch : IReturn<QueryResult<BaseItem>>
        {
            public QueryResult<BaseItem> items { get; set; }
        }

        private readonly ILogger _logger;
        private readonly IFileSystem _fileSystem;
        private readonly ILibraryManager _libraryManager;

        public SubEditAPI(ILogManager logManager, IFileSystem fileSystem, ILibraryManager libraryManager)
        {
            _logger = logManager.GetLogger(GetType().Namespace);
            _fileSystem = fileSystem;
            _libraryManager = libraryManager;
        }

        public QueryResult<BaseItem> Get(SubtitleSearch request)
        {
            InternalItemsQuery query = new InternalItemsQuery
            {
                IncludeItemTypes = new string[] { typeof(Movie).Name },
                SearchTerm = "Star trek",
                Recursive = true,
                DtoOptions = new DtoOptions(true),
                Limit = 50,
            };

            QueryResult<BaseItem> items = _libraryManager.GetItemsResult(query);

            return items;
        }
    }
}
