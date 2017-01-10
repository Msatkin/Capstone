import React from 'react';

import {
    Text,
    View,
    StyleSheet,
    Navigator
} from 'react-native';

var Login = require('./components/login');
var Account = require('./components/account');

var ROUTES = {
  login: Login,
  account: Account
};

module.exports = React.createClass({
  renderScene: function(route, navigator) {
    var Component = ROUTES[route.name];
    return <Component route={route} navigator={navigator} />;
  },
  render: function() {
    return (
      <Navigator
        style={ styles.container }
        initialRoute={ {name: 'login'} }
        renderScene={this.renderScene}
        configureScene={ () => { return Navigator.SceneConfigs.FloatFromRight; } }
      />
    );
  }
});

var styles = StyleSheet.create({
  container: {
    flex: 1
  }
});
