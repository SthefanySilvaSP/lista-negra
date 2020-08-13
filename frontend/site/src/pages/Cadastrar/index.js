import React, { useState } from 'react';
import './Cadastrar.css';

import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

import ListaNegraAPI from "../../services/ListaNegraAPI.js";
const api = new ListaNegraAPI();



export default function Cadastrar() {

    const [nome, setNome] = useState('');
    const [motivo, setMotivo] = useState('');

    const salvarClick = async () => {
        const resp = await 
            api.cadastrar({
                nome: nome,
                motivo: motivo
            });

        toast.dark("😈 Cadastrado(a) na Lista Negra");
    }

    return (
        <div className="cadastro">

            <h1>Cadastrar na Lista Negra</h1>
            
            <div className="info_cadastro">
                <div className="info">
                    <h2>Qual o nome da pessoa?</h2>
                    <input type="text" 
                           value={nome} 
                           placeholder="Digite aqui"
                           onChange={e => setNome(e.target.value)} />
                </div>
                <div className="info">
                    <h2>Por que quer cadastrar ela?</h2>
                    <input type="text" 
                           value={motivo}
                           placeholder="Digite aqui"
                           onChange={e => setMotivo(e.target.value)} />
                </div>
            </div>


            <button onClick={salvarClick} className="btn_salvar">Cadastrar</button>
            
            <ToastContainer />
        </div>
    );
}
