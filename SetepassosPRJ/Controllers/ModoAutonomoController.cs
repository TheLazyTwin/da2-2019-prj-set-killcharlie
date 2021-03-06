﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SetepassosPRJ.Models;

namespace SetepassosPRJ.Controllers
{
    public class ModoAutonomoController : Controller
    {
        [HttpGet]
        public IActionResult NovoAutoJogo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovoAutoJogo(int rondas)
        {
            HttpClient client = MyGameHTTPClient.Client;
            string path = "/api/NewGame";

            string nome = "";
            if(rondas == 3)
            {
                nome = "auto3";
            }
            else if(rondas == 7)
            {
                nome = "auto7";
            }
            else
            {
                nome = "auto0";
            }
            GameApiRequest req = new GameApiRequest(nome, "S");
            string json = JsonConvert.SerializeObject(req);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, path);
            request.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return Redirect("NovoAutoJogo");
            }

            string json_r = await response.Content.ReadAsStringAsync();

            GameApiResponse gr = JsonConvert.DeserializeObject<GameApiResponse>(json_r);

            Jogo novoJogo = new Jogo(nome, "S");
            novoJogo.AtualizarJogo(gr);

            //int ronda = 1;
            while (novoJogo.PontosVida != 0 && gr.Result != RoundResult.SuccessVictory)
            {
                path = "/api/Play";

                if(gr.RoundNumber == rondas)
                {
                    novoJogo.Acao = PlayerAction.Quit;
                    break;
                }
                else
                {
                    novoJogo.AutoPlay(gr, rondas);
                }

                PlayApiRequest pedido = new PlayApiRequest(novoJogo.ID, novoJogo.Acao);
                json = JsonConvert.SerializeObject(pedido);

                request = new HttpRequestMessage(HttpMethod.Post, path);
                request.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                response = await client.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    return Redirect("/");
                }

                json_r = await response.Content.ReadAsStringAsync();

                gr = JsonConvert.DeserializeObject<GameApiResponse>(json_r);
                novoJogo.AtualizarJogo(gr);
                //ronda++;
            }
            novoJogo.ScoreJogo();

            return View("Resultados",novoJogo);
        }
    }
}