//import react component using imrc shortcut
import React, { Component } from "react";
//create class using cc
class Counter extends Component {
  //state will be used in future modules
  // state = {  }
  state = {
    count: 0,
    imageUrl: "https://picsum.photos/200",
    tags: ["tag1", "tag2", "tag3"],
  };
  render() {
    //same parent for all JSX elements since React.createElement method takes type of element as parameter for example h1
    //use SHIFT + ALT + F to use prettier formatter
    return (
      //   <div> --> removed <div> since we don't want extra div
      <React.Fragment>
        <h1>Hello World</h1>
        {/* Setting Expressions: we can write any **expression** between curly braces i.e. expression returning value or function returning value
         e.g. 2+2 */}
        <span>{this.state.count}</span>
        <span>{this.formatCount()}</span>
        {/* Setting attributes */}
        <img src={this.state.imageUrl} alt="" />
        <span className="badge badge-primary m-2">{this.formatCount()}</span>
        {/* //Rendering CSS classes dynamically - rewrite above span with dynamic class name */}
        <span className={this.getBadgeClasses()}>{this.formatCount()}</span>
        {/* Rendering list dynamically */}
        <ul>
          {this.state.tags.map((tag) => (
            //   add key attribute  to avoid error - Each child in a list should have a unique "key" prop.
            <li key={tag}>{tag}</li>
          ))}
        </ul>
        <button className="btn btn-secondary btn-sm">Increment</button>
      </React.Fragment>
      //   </div>
    );
  }

  getBadgeClasses() {
    let classes = "badge m-2 badge-";
    classes += this.state.count === 0 ? "warning" : "primary";
    return classes;
  }

  formatCount() {
    //initializes count constant with count property in state
    const { count } = this.state;
    return count === 0 ? "Zero" : count;
  }
}

export default Counter;
