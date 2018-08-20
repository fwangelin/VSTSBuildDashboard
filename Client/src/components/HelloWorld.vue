<template>
  <div class="hello">
    <h1>{{ foo}}</h1>
  </div>
</template>

<script>
export default {
  name: 'HelloWorld',
  data () {
    return {
      msg: 'Welcome to Your Vue.js App',
      foo: null  
    }
  },
  beforeCreate() {
    
  },
  mounted(){
this.axios.get("https://localhost:44328/api/build").then(x => JSON.parse(x.request.response)).then(x => {this.foo = x }).catch(x => console.log(x))
  },
  methods: {
    yeboi (event) {
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1, h2 {
  font-weight: normal;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
