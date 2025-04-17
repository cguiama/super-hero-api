const { withModuleFederationPlugin } = require('@angular-architects/module-federation/webpack');

module.exports = withModuleFederationPlugin({

  name: 'heroesMfe', 

  exposes: { 
    './HeroesRoutes': './src/app/heroes/heroes.routes.ts',
  },

  shared: {
    "@angular/core": { singleton: true, strictVersion: true },
    "@angular/common": { singleton: true, strictVersion: true },
    "@angular/router": { singleton: true, strictVersion: true },
    "rxjs": { singleton: true, strictVersion: true },
  },

});
