﻿using System;
using System.Reactive.Threading.Tasks;
using Octokit.Reactive.Internal;

namespace Octokit.Reactive
{
    /// <summary>
    /// A client for GitHub's Repository Forks API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developer.github.com/v3/repos/forks/">Forks API documentation</a> for more information.
    /// </remarks>
    public class ObservableRepositoryForksClient : IObservableRepositoryForksClient
    {
        readonly IRepositoryForksClient _client;
        readonly IConnection _connection;

        /// <summary>
        /// Initializes a new GitHub Repos Fork API client.
        /// </summary>
        /// <param name="client"></param>
        public ObservableRepositoryForksClient(IGitHubClient client)
        {
            Ensure.ArgumentNotNull(client, "client");

            _client = client.Repository.Forks;
            _connection = client.Connection;
        }

        /// <summary>
        /// Gets the list of forks defined for a repository
        /// </summary>
        /// <remarks>
        /// See <a href="http://developer.github.com/v3/repos/forks/#list-forks">API documentation</a> for more information.
        /// </remarks>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <returns></returns>
        public IObservable<Repository> GetAll(string owner, string name)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(name, "name");

            return GetAll(owner, name, ApiOptions.None);
        }

        /// <summary>
        /// Gets the list of forks defined for a repository
        /// </summary>
        /// <remarks>
        /// See <a href="http://developer.github.com/v3/repos/forks/#list-forks">API documentation</a> for more information.
        /// </remarks>
        /// <param name="repositoryId">The ID of the repository</param>
        /// <returns></returns>
        public IObservable<Repository> GetAll(int repositoryId)
        {
            return GetAll(repositoryId, ApiOptions.None);
        }

        /// <summary>
        /// Gets the list of forks defined for a repository
        /// </summary>
        /// <remarks>
        /// See <a href="http://developer.github.com/v3/repos/forks/#list-forks">API documentation</a> for more information.
        /// </remarks>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <param name="options">Options for changing the API response</param>
        /// <returns></returns>
        public IObservable<Repository> GetAll(string owner, string name, ApiOptions options)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(name, "name");
            Ensure.ArgumentNotNull(options, "options");

            return _connection.GetAndFlattenAllPages<Repository>(ApiUrls.RepositoryForks(owner, name), options);
        }

        /// <summary>
        /// Gets the list of forks defined for a repository
        /// </summary>
        /// <remarks>
        /// See <a href="http://developer.github.com/v3/repos/forks/#list-forks">API documentation</a> for more information.
        /// </remarks>
        /// <param name="repositoryId">The ID of the repository</param>
        /// <param name="options">Options for changing the API response</param>
        /// <returns></returns>
        public IObservable<Repository> GetAll(int repositoryId, ApiOptions options)
        {
            Ensure.ArgumentNotNull(options, "options");

            return _connection.GetAndFlattenAllPages<Repository>(ApiUrls.RepositoryForks(repositoryId), options);
        }

        /// <summary>
        /// Gets the list of forks defined for a repository
        /// </summary>
        /// <remarks>
        /// See <a href="http://developer.github.com/v3/repos/forks/#list-forks">API documentation</a> for more information.
        /// </remarks>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <param name="request">Used to request and filter a list of repository forks</param>
        /// <returns></returns>
        public IObservable<Repository> GetAll(string owner, string name, RepositoryForksListRequest request)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(name, "name");
            Ensure.ArgumentNotNull(request, "request");

            return GetAll(owner, name, request, ApiOptions.None);
        }

        /// <summary>
        /// Gets the list of forks defined for a repository
        /// </summary>
        /// <remarks>
        /// See <a href="http://developer.github.com/v3/repos/forks/#list-forks">API documentation</a> for more information.
        /// </remarks>
        /// <param name="repositoryId">The ID of the repository</param>
        /// <param name="request">Used to request and filter a list of repository forks</param>
        /// <returns></returns>
        public IObservable<Repository> GetAll(int repositoryId, RepositoryForksListRequest request)
        {
            Ensure.ArgumentNotNull(request, "request");

            return GetAll(repositoryId, request, ApiOptions.None);
        }

        /// <summary>
        /// Gets the list of forks defined for a repository
        /// </summary>
        /// <remarks>
        /// See <a href="http://developer.github.com/v3/repos/forks/#list-forks">API documentation</a> for more information.
        /// </remarks>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <param name="request">Used to request and filter a list of repository forks</param>
        /// <param name="options">Options for changing the API response</param>
        /// <returns></returns>
        public IObservable<Repository> GetAll(string owner, string name, RepositoryForksListRequest request, ApiOptions options)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(name, "name");
            Ensure.ArgumentNotNull(options, "options");

            return request == null ? _connection.GetAndFlattenAllPages<Repository>(ApiUrls.RepositoryForks(owner, name), options) :
                _connection.GetAndFlattenAllPages<Repository>(ApiUrls.RepositoryForks(owner, name), request.ToParametersDictionary(), options);
        }

        /// <summary>
        /// Gets the list of forks defined for a repository
        /// </summary>
        /// <remarks>
        /// See <a href="http://developer.github.com/v3/repos/forks/#list-forks">API documentation</a> for more information.
        /// </remarks>
        /// <param name="repositoryId">The ID of the repository</param>
        /// <param name="request">Used to request and filter a list of repository forks</param>
        /// <param name="options">Options for changing the API response</param>
        /// <returns></returns>
        public IObservable<Repository> GetAll(int repositoryId, RepositoryForksListRequest request, ApiOptions options)
        {
            Ensure.ArgumentNotNull(options, "options");

            return request == null ? _connection.GetAndFlattenAllPages<Repository>(ApiUrls.RepositoryForks(repositoryId), options) :
                _connection.GetAndFlattenAllPages<Repository>(ApiUrls.RepositoryForks(repositoryId), request.ToParametersDictionary(), options);
        }

        /// <summary>
        /// Creates a fork for a repository. Specify organization in the fork parameter to create for an organization.
        /// </summary>
        /// <remarks>
        /// See <a href="http://developer.github.com/v3/repos/forks/#create-a-fork">API documentation</a> for more information.
        /// </remarks>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <param name="fork">Used to fork a repository</param>
        /// <returns></returns>
        public IObservable<Repository> Create(string owner, string name, NewRepositoryFork fork)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(name, "name");
            Ensure.ArgumentNotNull(fork, "fork");

            return _client.Create(owner, name, fork).ToObservable();
        }

        /// <summary>
        /// Creates a fork for a repository. Specify organization in the fork parameter to create for an organization.
        /// </summary>
        /// <remarks>
        /// See <a href="http://developer.github.com/v3/repos/forks/#create-a-fork">API documentation</a> for more information.
        /// </remarks>
        /// <param name="repositoryId">The ID of the repository</param>
        /// <param name="fork">Used to fork a repository</param>
        /// <returns></returns>
        public IObservable<Repository> Create(int repositoryId, NewRepositoryFork fork)
        {
            Ensure.ArgumentNotNull(fork, "fork");

            return _client.Create(repositoryId, fork).ToObservable();
        }
    }
}