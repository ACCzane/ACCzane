using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;

public class HostGameManager
{
    private Allocation allocation;
    private string joinCode;
    private const int maxConnections = 20;
    private const string gameSceneName = "Game";
    public async Task StartHostAsync(){
        try{
            allocation = await Relay.Instance.CreateAllocationAsync(maxConnections);
        }catch(Exception e){
            Debug.Log(e);
            return;
        }

        try{
            joinCode =  await Relay.Instance.GetJoinCodeAsync(allocation.AllocationId);
            Debug.Log(joinCode);
        }catch (Exception e){
            Debug.Log(e);
            return;
        }

        UnityTransport transport = NetworkManager.Singleton.GetComponent<UnityTransport>();

        RelayServerData relayServerData = new RelayServerData(allocation, "udp");
        transport.SetRelayServerData(relayServerData);
        
        NetworkManager.Singleton.StartHost();

        NetworkManager.Singleton.SceneManager.LoadScene(gameSceneName, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
