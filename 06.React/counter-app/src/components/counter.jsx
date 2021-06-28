//import react component using imrc shortcut
import React, { Component } from "react";
//create class using cc
class Counter extends Component {
  //state will be used in future modules
  // state = {  }
  render() {
    //same parent for all JSX elements since React.createElement method takes type of element as parameter for example h1
    //use SHIFT + ALT + F to use prettier formatter
    return (
      //   <div> --> removed <div> since we don't want extra div
      <React.Fragment>
        <h1>Hello World</h1>
        <button>Increment</button>
      </React.Fragment>
      //   </div>
    );
  }
}

export default Counter;
