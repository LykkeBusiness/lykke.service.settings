﻿using Common.Log;
using Core.Enums;
using Core.Models;

namespace Core.Services
{
    public interface IGitService
    {
        SourceControlTypes ResolveSourceControlTypeFromUrl(string url);
        string GetGitRepositoryName(string gitUrl, SourceControlTypes type);
        string GenerateRepositorySettingsGitUrl(
            string gitUrl,
            SourceControlTypes type,
            string branch = "");
        ServiceResult DownloadSettingsFileFromGit(
            ILog log,
            string url,
            SourceControlTypes type);
    }
}