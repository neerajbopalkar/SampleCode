import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import 'bootstrap/dist/css/bootstrap.css';
//getting error below on only importing bootstrap. Hence need to install jquery and popper.js
//: https://stackoverflow.com/questions/49589282/bootstrap-in-react-cant-resolve-jquery-module
import $ from 'jquery';
import Popper from 'popper.js';
import Counter from './components/counter' 

ReactDOM.render(
  <React.StrictMode>
    {/* <App /> */}
    {/* Instead of App, render Component counter */}
    <Counter/>
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
