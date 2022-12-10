// External "library" yoinked from internet
// https://codesweetly.com/

import React from "react";
import { Component } from "react";

// Creat an ElementMaker component
class ElementMaker extends Component {
    // Render a <span> element
    render() {
        return (
            <span>
        {
            // Use JavaScript's ternary operator to specify <span>'s inner content
            this.props.showInputEle ? (
                <input
                    type="text"
                    value={this.props.value}
                    onChange={this.props.handleChange}
                    onBlur={this.props.handleBlur}
                    autoFocus
                />
            ) : (
                <span
                    onDoubleClick={this.props.handleDoubleClick}
                    style={{
                        display: "inline-block",
                        height: "25px",
                        minWidth: "300px",
                    }}
                >
              {this.props.value}
            </span>
            )
        }
      </span>
        );
    }
}

export default ElementMaker;