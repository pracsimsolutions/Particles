<?xml version="1.0" encoding="UTF-8"?>
<flexsim-tree version="4" treetype="tree">
<node f="42"><name>Particles</name>
 <node f="40"><name></name></node>
 <node f="42"><name>installdata</name>
  <node f="40"><name></name></node>
  <node f="42" dt="2"><name>add_library</name><data>MAIN:/project/library</data>
   <node f="40"><name></name></node>
   <node f="42" dt="3"><name>Particles</name><data><coupling>null</coupling></data>
    <node f="40"><name></name></node>
    <node f="42" dt="1"><name>rank</name><data>0000000000000000</data></node>
    <node f="42" dt="2"><name>after</name><data>fluid</data></node>
    <node f="42" dt="1"><name>into object</name><data>0000000000000000</data></node>
    <node f="42"><name>data</name>
     <node f="40"><name></name></node>
     <node f="42"><name>Particles</name>
      <node f="40"><name></name></node>
      <node f="10000062" dt="4"><name>ParticleSystem</name><data>
       <node f="40"><name></name></node>
       <node f="42"><name>classes</name>
        <node f="40"><name></name></node>
        <node f="42" dt="3"><name>Particles::ParticleSystem</name><data><coupling>/installdata/add_library/Particles/data/Particles/ParticleSystem</coupling></data></node>
       </node>
       <node f="42"><name>superclasses</name>
        <node f="40"><name></name></node>
        <node f="42" dt="3"><name>FlexSimEventHandler</name><data><coupling>null</coupling></data></node>
       </node>
       <node f="42"><name>variables</name>
        <node f="80000040"><name></name></node>
        <node f="42" dt="1"><name>pointSize</name><data>0000000040140000</data></node>
        <node f="42" dt="1"><name>liveCap</name><data>0000000041086a00</data></node>
        <node f="42" dt="1"><name>statEmitterCount</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>statTotalLive</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>statBuildMs</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>statDrawMs</name><data>0000000000000000</data></node>
       </node>
       <node f="42"><name>behaviour</name>
        <node f="40"><name></name></node>
        <node f="42"><name>eventfunctions</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>flexScriptInterface</name><data></data></node>
        </node>
       </node>
       <node f="42"><name>visual</name>
        <node f="40"><name></name></node>
        <node f="42"><name>color</name>
         <node f="40"><name></name></node>
         <node f="42" dt="1"><name>red</name><data>9999999a3fd99999</data></node>
         <node f="42" dt="1"><name>green</name><data>9999999a3fe99999</data></node>
         <node f="42" dt="1"><name>blue</name><data>00000000400c0000</data></node>
        </node>
        <node f="42" dt="2"><name>shape</name><data></data></node>
        <node f="42" dt="1"><name>shapeindex</name><data>0000000000000000</data></node>
        <node f="42" dt="2"><name>picture</name><data>bitmaps\ParticleSystem.png</data></node>
        <node f="42" dt="2"><name>imageobject</name><data>***</data></node>
        <node f="42" dt="1"><name>imageindexobject</name><data>0000000000000000</data></node>
        <node f="42" dt="2"><name>imagebase</name><data>***</data></node>
        <node f="42" dt="1"><name>imageindexbase</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>drawflags</name><data>0000000000000000</data></node>
       </node>
       <node f="42"><name>special</name>
        <node f="40"><name></name></node>
        <node f="42" dt="2"><name>title</name><data>Particle System</data></node>
        <node f="42" dt="2"><name>description</name><data>Manages and batch-draws all particle emitters in the model.</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/standardviews/modelingutilities/QuickerProperties</data></node>
       </node>
       <node f="42"><name>spatial</name>
        <node f="40"><name></name></node>
        <node f="42" dt="1"><name>spatialx</name><data>00000000c0140000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>0000000040080000</data></node>
        <node f="42" dt="1"><name>spatialz</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>000000003ff00000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>000000003ff00000</data></node>
        <node f="42" dt="1"><name>spatialsz</name><data>000000003ff00000</data></node>
        <node f="42" dt="1"><name>spatialrx</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>spatialry</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>spatialrz</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>centroid</name><data>000000003ff00000</data></node>
       </node>
       <node f="42" dt="2"><name>windowtitle</name><data>ParticleSystem</data></node>
      </data></node>
      <node f="10000042" dt="4"><name>ParticleEmitter</name><data>
       <node f="40"><name></name></node>
       <node f="42"><name>classes</name>
        <node f="40"><name></name></node>
        <node f="42" dt="3"><name>Particles::ParticleEmitter</name><data><coupling>/installdata/add_library/Particles/data/Particles/ParticleEmitter</coupling></data></node>
       </node>
       <node f="42"><name>variables</name>
        <node f="40"><name></name></node>
        <node f="42" dt="1"><name>rate</name><data>0000000040690000</data></node>
        <node f="42" dt="1"><name>lifetime</name><data>0000000040000000</data></node>
        <node f="42" dt="1"><name>lifetimeJitter</name><data>9999999a3fd99999</data></node>
        <node f="42" dt="1"><name>startTime</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>stopTimeField</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>shapeField</name><data>000000003ff00000</data></node>
        <node f="42" dt="1"><name>coneHalfAngleDeg</name><data>0000000040390000</data></node>
        <node f="42" dt="1"><name>shapeSize</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>speed</name><data>0000000040000000</data></node>
        <node f="42" dt="1"><name>speedJitter</name><data>000000003fe00000</data></node>
        <node f="42" dt="1"><name>gravX</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>gravY</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>gravZ</name><data>00000000c0000000</data></node>
        <node f="42" dt="1"><name>drag</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>windX</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>windY</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>windZ</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>swirlAmp</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>swirlFreq</name><data>000000003ff00000</data></node>
        <node f="42" dt="1"><name>sizeStart</name><data>9999999a3fc99999</data></node>
        <node f="42" dt="1"><name>sizeEnd</name><data>9999999a3fa99999</data></node>
        <node f="42" dt="1"><name>alphaStart</name><data>000000003ff00000</data></node>
        <node f="42" dt="1"><name>alphaEnd</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>colorStartR</name><data>000000003ff00000</data></node>
        <node f="42" dt="1"><name>colorStartG</name><data>000000003ff00000</data></node>
        <node f="42" dt="1"><name>colorStartB</name><data>000000003ff00000</data></node>
        <node f="42" dt="1"><name>colorEndR</name><data>000000003ff00000</data></node>
        <node f="42" dt="1"><name>colorEndG</name><data>000000003ff00000</data></node>
        <node f="42" dt="1"><name>colorEndB</name><data>000000003ff00000</data></node>
        <node f="42" dt="1"><name>styleField</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>textureIndex</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>seedField</name><data>0000000040c81c80</data></node>
        <node f="42" dt="1"><name>statLiveCount</name><data>0000000000000000</data></node>
       </node>
       <node f="42"><name>behaviour</name>
        <node f="40"><name></name></node>
        <node f="42"><name>eventfunctions</name>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name>flexScriptInterface</name><data></data></node>
         <node f="442" dt="2"><name>OnCreate</name><data>// Auto-create the singleton ParticleSystem on first emitter drop.
if (model().find("ParticleSystem") == NULL) {
	treenode sys = createinstance(library().find("?ParticleSystem"), model());
	sys.name = "ParticleSystem";
}</data></node>
         <node f="42"><name>configs</name>
          <node f="40"><name></name></node>
          <node f="42" dt="4"><name>Emitter</name><data>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>picture</name><data>modules\Particles\bitmaps\ParticleEmitter.png</data></node>
           <node f="4000000042" dt="2"><name>windowtitle</name><data>Emitter</data></node>
          </data>
           <node f="40"><name></name></node>
           <node f="42"><name>variables</name>
            <node f="40"><name></name></node>
            <node f="42" dt="1"><name>styleField</name><data>0000000000000000</data></node>
            <node f="42" dt="1"><name>rate</name><data>0000000040690000</data></node>
            <node f="42" dt="1"><name>lifetime</name><data>0000000040000000</data></node>
            <node f="42" dt="1"><name>lifetimeJitter</name><data>9999999a3fd99999</data></node>
            <node f="42" dt="1"><name>shapeField</name><data>000000003ff00000</data></node>
            <node f="42" dt="1"><name>coneHalfAngleDeg</name><data>0000000040390000</data></node>
            <node f="42" dt="1"><name>speed</name><data>0000000040000000</data></node>
            <node f="42" dt="1"><name>speedJitter</name><data>000000003fe00000</data></node>
            <node f="42" dt="1"><name>gravZ</name><data>00000000c0000000</data></node>
            <node f="42" dt="1"><name>drag</name><data>0000000000000000</data></node>
            <node f="42" dt="1"><name>sizeStart</name><data>9999999a3fc99999</data></node>
            <node f="42" dt="1"><name>sizeEnd</name><data>9999999a3fa99999</data></node>
            <node f="42" dt="1"><name>alphaStart</name><data>000000003ff00000</data></node>
            <node f="42" dt="1"><name>alphaEnd</name><data>0000000000000000</data></node>
            <node f="42" dt="1"><name>colorStartR</name><data>000000003ff00000</data></node>
            <node f="42" dt="1"><name>colorStartG</name><data>000000003ff00000</data></node>
            <node f="42" dt="1"><name>colorStartB</name><data>000000003ff00000</data></node>
            <node f="42" dt="1"><name>colorEndR</name><data>000000003ff00000</data></node>
            <node f="42" dt="1"><name>colorEndG</name><data>000000003ff00000</data></node>
            <node f="42" dt="1"><name>colorEndB</name><data>000000003ff00000</data></node>
           </node>
          </node>
          <node f="42" dt="4"><name>Smoke</name><data>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>picture</name><data>modules\Particles\bitmaps\Smoke.png</data></node>
           <node f="4000000042" dt="2"><name>windowtitle</name><data>Smoke</data></node>
          </data>
           <node f="40"><name></name></node>
           <node f="42"><name>variables</name>
            <node f="40"><name></name></node>
            <node f="42" dt="1"><name>styleField</name><data>000000003ff00000</data></node>
            <node f="42" dt="1"><name>rate</name><data>00000000404e0000</data></node>
            <node f="42" dt="1"><name>lifetime</name><data>0000000040080000</data></node>
            <node f="42" dt="1"><name>speed</name><data>9999999a3fe99999</data></node>
            <node f="42" dt="1"><name>speedJitter</name><data>333333333fd33333</data></node>
            <node f="42" dt="1"><name>coneHalfAngleDeg</name><data>0000000040320000</data></node>
            <node f="42" dt="1"><name>gravZ</name><data>9999999a3fd99999</data></node>
            <node f="42" dt="1"><name>drag</name><data>333333333fe33333</data></node>
            <node f="42" dt="1"><name>sizeStart</name><data>333333333fd33333</data></node>
            <node f="42" dt="1"><name>sizeEnd</name><data>333333333ff33333</data></node>
            <node f="42" dt="1"><name>alphaStart</name><data>000000003fe00000</data></node>
            <node f="42" dt="1"><name>colorStartR</name><data>000000003fe80000</data></node>
            <node f="42" dt="1"><name>colorStartG</name><data>000000003fe80000</data></node>
            <node f="42" dt="1"><name>colorStartB</name><data>8f5c28f63fe8f5c2</data></node>
            <node f="42" dt="1"><name>colorEndR</name><data>000000003fe00000</data></node>
            <node f="42" dt="1"><name>colorEndG</name><data>000000003fe00000</data></node>
            <node f="42" dt="1"><name>colorEndB</name><data>9999999a3fe19999</data></node>
           </node>
          </node>
          <node f="42" dt="4"><name>Sparks</name><data>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>picture</name><data>modules\Particles\bitmaps\Sparks.png</data></node>
           <node f="4000000042" dt="2"><name>windowtitle</name><data>Sparks</data></node>
          </data>
           <node f="40"><name></name></node>
           <node f="42"><name>variables</name>
            <node f="40"><name></name></node>
            <node f="42" dt="1"><name>styleField</name><data>0000000000000000</data></node>
            <node f="42" dt="1"><name>rate</name><data>000000004062c000</data></node>
            <node f="42" dt="1"><name>lifetime</name><data>000000003ff00000</data></node>
            <node f="42" dt="1"><name>speed</name><data>0000000040100000</data></node>
            <node f="42" dt="1"><name>speedJitter</name><data>0000000040000000</data></node>
            <node f="42" dt="1"><name>coneHalfAngleDeg</name><data>0000000040418000</data></node>
            <node f="42" dt="1"><name>gravZ</name><data>00000000c0180000</data></node>
            <node f="42" dt="1"><name>sizeStart</name><data>9999999a3fa99999</data></node>
            <node f="42" dt="1"><name>sizeEnd</name><data>47ae147b3f947ae1</data></node>
            <node f="42" dt="1"><name>colorStartR</name><data>000000003ff00000</data></node>
            <node f="42" dt="1"><name>colorStartG</name><data>cccccccd3feccccc</data></node>
            <node f="42" dt="1"><name>colorStartB</name><data>9999999a3fd99999</data></node>
            <node f="42" dt="1"><name>colorEndR</name><data>000000003ff00000</data></node>
            <node f="42" dt="1"><name>colorEndG</name><data>333333333fd33333</data></node>
            <node f="42" dt="1"><name>colorEndB</name><data>9999999a3fa99999</data></node>
           </node>
          </node>
          <node f="42" dt="4"><name>Fountain</name><data>
           <node f="40"><name></name></node>
           <node f="42" dt="2"><name>picture</name><data>modules\Particles\bitmaps\Fountain.png</data></node>
           <node f="4000000042" dt="2"><name>windowtitle</name><data>Fountain</data></node>
          </data>
           <node f="40"><name></name></node>
           <node f="42"><name>variables</name>
            <node f="40"><name></name></node>
            <node f="42" dt="1"><name>styleField</name><data>0000000000000000</data></node>
            <node f="42" dt="1"><name>rate</name><data>000000004072c000</data></node>
            <node f="42" dt="1"><name>lifetime</name><data>0000000040040000</data></node>
            <node f="42" dt="1"><name>speed</name><data>0000000040100000</data></node>
            <node f="42" dt="1"><name>speedJitter</name><data>333333333fe33333</data></node>
            <node f="42" dt="1"><name>coneHalfAngleDeg</name><data>0000000040280000</data></node>
            <node f="42" dt="1"><name>gravZ</name><data>00000000c0080000</data></node>
            <node f="42" dt="1"><name>sizeStart</name><data>47ae147b3fb47ae1</data></node>
            <node f="42" dt="1"><name>colorStartR</name><data>9999999a3fd99999</data></node>
            <node f="42" dt="1"><name>colorStartG</name><data>666666663fe66666</data></node>
            <node f="42" dt="1"><name>colorStartB</name><data>000000003ff00000</data></node>
            <node f="42" dt="1"><name>colorEndR</name><data>9999999a3fb99999</data></node>
            <node f="42" dt="1"><name>colorEndG</name><data>333333333fd33333</data></node>
            <node f="42" dt="1"><name>colorEndB</name><data>cccccccd3feccccc</data></node>
           </node>
          </node>
         </node>
        </node>
       </node>
       <node f="42"><name>visual</name>
        <node f="40"><name></name></node>
        <node f="42"><name>color</name>
         <node f="40"><name></name></node>
         <node f="42" dt="1"><name>red</name><data>9999999a3fb99999</data></node>
         <node f="42" dt="1"><name>green</name><data>6666666666e63f66</data></node>
         <node f="42" dt="1"><name>blue</name><data>000000003ff00000</data></node>
        </node>
        <node f="42" dt="2"><name>shape</name><data></data></node>
        <node f="42" dt="1"><name>shapeindex</name><data>0000000000000000</data></node>
        <node f="42" dt="2"><name>picture</name><data>bitmaps\ParticleEmitter.png</data></node>
        <node f="42" dt="2"><name>imageobject</name><data>***</data></node>
        <node f="42" dt="1"><name>imageindexobject</name><data>0000000000000000</data></node>
        <node f="42" dt="2"><name>imagebase</name><data>***</data></node>
        <node f="42" dt="1"><name>imageindexbase</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>drawflags</name><data>0000000000000000</data></node>
       </node>
       <node f="42"><name>special</name>
        <node f="40"><name></name></node>
        <node f="42" dt="2"><name>title</name><data>Particle Emitter</data></node>
        <node f="42" dt="2"><name>description</name><data>Emits particles at draw time as an analytic function of model time. Drop one or more; the Particle System is created automatically.</data></node>
        <node f="42" dt="2"><name>guifocusclass</name><data>VIEW:/standardviews/modelingutilities/QuickerProperties</data></node>
       </node>
       <node f="42"><name>spatial</name>
        <node f="40"><name></name></node>
        <node f="42" dt="1"><name>spatialx</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>spatialy</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>spatialz</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>spatialsx</name><data>000000003fd00000</data></node>
        <node f="42" dt="1"><name>spatialsy</name><data>000000003fd00000</data></node>
        <node f="42" dt="1"><name>spatialsz</name><data>000000003fd00000</data></node>
        <node f="42" dt="1"><name>spatialrx</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>spatialry</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>spatialrz</name><data>0000000000000000</data></node>
        <node f="42" dt="1"><name>centroid</name><data>000000003ff00000</data></node>
       </node>
       <node f="42" dt="2"><name>windowtitle</name><data>ParticleEmitter</data></node>
      </data></node>
     </node>
    </node>
   </node>
  </node>
  <node f="42" dt="2"><name>add_modules</name><data>VIEW:/modules</data>
   <node f="40"><name></name></node>
   <node f="42" dt="3"><name>Particles</name><data><coupling>null</coupling></data>
    <node f="40"><name></name></node>
    <node f="42" dt="1"><name>rank</name><data>0000000000000000</data></node>
    <node f="42"><name>after</name></node>
    <node f="42" dt="1"><name>into object</name><data>0000000000000000</data></node>
    <node f="42"><name>data</name>
     <node f="40"><name></name></node>
     <node f="42"><name>Particles</name>
      <node f="40"><name></name></node>
      <node f="42"><name>LibraryGroup</name>
       <node f="40"><name></name></node>
       <node f="42" dt="4"><name>Emitter</name><data>
        <node f="40"><name></name></node>
        <node f="4000000042" dt="2"><name>windowtitle</name><data>Emitter</data></node>
        <node f="4000000042" dt="2"><name>tooltip</name><data>An object used to define locations in geographic coordinates</data></node>
        <node f="42" dt="2"><name>picture</name><data>modules\Particles\bitmaps\ParticleEmitter.png</data>
         <node f="40"><name></name></node>
         <node f="42" dt="2"><name></name><data>bitmaps\popOut.png</data></node>
        </node>
        <node f="42" dt="2"><name>popOutChoices</name><data>MAIN:/project/library/Particles/ParticleEmitter&gt;behaviour/eventfunctions/configs</data></node>
        <node f="42"><name>eventfunctions</name>
         <node f="40"><name></name></node>
         <node f="442" dt="2"><name>customDropScript</name><data>treenode template = param(1);
treenode dragTo = param(2);
double dropX = param(3);
double dropY = param(4);
double dropZ = param(5);
treenode view = param(6);

treenode obj = dropuserlibraryobject(template, dragTo, dropX, dropY, dropZ, view);

//Apply any changes specified by the subnodes of the template shape
for(int j = 1; j &lt;= template.subnodes.length; j++)
{
	treenode copyFrom = template.subnodes[j];
	treenode copyTo = obj.find("&gt;" + copyFrom.name);
	if (objectexists(copyTo)){
		for (int k = 1; k &lt;= copyFrom.subnodes.length; k++){
			if (copyTo.subnodes[copyFrom.subnodes[k].name]){
				createcopy(copyFrom.subnodes[k], copyTo.subnodes[copyFrom.subnodes[k].name], 1, 0, 0, 1);
			}
			else {
				createcopy(copyFrom.subnodes[k], copyTo.subnodes[copyFrom.subnodes[k].name], 1, 0, 0, 0);
			}
		}
	}
}
rebindobjectattributes(obj);

</data></node>
        </node>
       </data></node>
      </node>
     </node>
    </node>
   </node>
  </node>
  <node f="42" dt="2"><name>add_list</name><data>VIEW:/standardviews/modelingutilities/LibraryIconGrid/GroupIconGrid&gt;variables/visibilityLists/base/list</data>
   <node f="40"><name></name></node>
   <node f="42" dt="3"><name>Particles</name><data><coupling>null</coupling></data>
    <node f="40"><name></name></node>
    <node f="42" dt="1"><name>rank</name><data>0000000000000000</data></node>
    <node f="42" dt="2"><name>after</name><data>Fluid</data></node>
    <node f="42" dt="1"><name>into object</name><data>0000000000000000</data></node>
    <node f="42"><name>data</name>
     <node f="40"><name></name></node>
     <node f="42" dt="4"><name>Particles</name><data>
      <node f="40"><name></name></node>
      <node f="42" dt="2"><name>viewfocus</name><data>VIEW:/modules/Particles/LibraryGroup</data></node>
      <node f="42" dt="1"><name>picturealignleft</name><data>0000000040360000</data></node>
      <node f="42" dt="1"><name>expanded</name><data>000000003ff00000</data></node>
      <node f="4000000042" dt="2"><name>windowtitle</name><data>Particles</data></node>
     </data>
      <node f="40"><name></name></node></node>
    </node>
   </node>
  </node>
 </node>
</node></flexsim-tree>
