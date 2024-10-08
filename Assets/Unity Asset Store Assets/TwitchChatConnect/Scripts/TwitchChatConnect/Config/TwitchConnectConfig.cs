﻿using System;
using UnityEngine;

namespace TwitchChatConnect.Config
{
    [Serializable]
    public class TwitchConnectConfig
    {
        [SerializeField] public string username;
        [SerializeField] public string userToken;
        [SerializeField] public string channelName;

        public string Username => username.ToLower();
        public string UserToken => userToken;
        public string ChannelName => channelName;

        public TwitchConnectConfig(string username, string userToken, string channelName)
        {
            this.username = username;
            this.userToken = userToken;
            this.channelName = channelName;
        }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(UserToken) && !string.IsNullOrEmpty(ChannelName);
        }
    }
}