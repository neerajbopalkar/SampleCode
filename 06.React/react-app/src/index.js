//object from react is imported into React
import React from 'react';
import ReactDOM from 'react-dom';

//this internally gives call to React.createElement. Hence react library is imported. 
const element = <h1>Hello World</h1>;

//console.log(element);

//Above element is created in virtual DOM. Now need to create this element in REAL DOM.

//here element is rendered inside element with ID ROOT
ReactDOM.render(element, document.getElementById('root'));