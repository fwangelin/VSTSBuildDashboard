<template>
  <div id="app">
   
    <router-view/>
  </div>
</template>

 <script>
// export default {
//   name: 'App'
// }
// </script>
export default {
  methods: {
    test () {
      this.$Progress.start()
      this.$http.jsonp('https://localhost:44328/api/build?buildId=300')
      .then((response) => {
          this.$Progress.finish()
      }, (response) => {
          this.$Progress.fail()
      })
    }
  }
}
</script> 

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
body { 
  background: url(./images/build.jpg) no-repeat center center fixed; 
  -webkit-background-size: cover;
  -moz-background-size: cover;
  -o-background-size: cover;
  background-size: cover;
  

}


</style>
