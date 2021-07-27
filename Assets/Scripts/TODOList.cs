using UnityEditor;
using UnityEngine;

namespace HQRDa
{

    namespace NQSH
    {
        public class TODOList
        {
            // DONE - Add Combo loss overtime

            // DONE - Create Library
            // DONE - Add new class for CheckPointsList in Library
            // DONE - Add new class for WaveList in Library
            // DONE - Add new class for EnemyList in Library
            // DONE - Add The Worm wave to Library

            // DONE - Create new class for Basic Enemy
            // DONE - Create new class for Boss (Head & Body)
            // DONE - Enemy Factory Refont            

            // DONE - Enemy HealthBar appear when isn't full HP

            // >TODO - Add Spawn area VisualAlert
            // >TODO - Add ShotLoading effect in General Factory
            // >TODO - Add Combo loss when touch by enemy's hitbox <<< For some enemies only
            // >TODO - Creer une zone plus large pour la destrcution des projectiles > Sinn quand l'ennemi est en dehors de l'ecran
            //      les projectiles sont detruits directement
            // >TODO - Ajouter effet d'impact quand touché > Creer un gameObject en Child avec meme apparence(Sprite), teinte Rouge, Opacité reduite, puis le détruire 0.1 seconde apres;
            // >TODO - Enemy shot with Frencency balancing

            // ===============
            // =   ENEMIES   =
            // ===============

            // --- Basic ---

            // DONE - Add Enemy with normal single shot, following the wave's checkpoints list.
            // DONE - Add Enemy with circle shot, picking a random checkpoint to move around.
            // DONE - Add Enemy with spiral shot, picking a random checkpoint to move around.
            // >TODO - Ennemi qui bouge rapidement d'un checkpoint a l'autre mais y stagne quelques secondes en chargeant un tir laser dirigé vers la position du joueur quand il est arrivé au checkpoint
            //      puis le relache avant de bouger au checkpoint suivant.
            // >TODO - Ennemi qui garde un checkpoint fixe mais bouger aleatoirement autour de celui ci. Vise constamment le joueur et tire a une frequence a definir.

            // --- Boss ---

            // DONE - Add Boss > The Worm

            // ================
            // =  BEHAVIOURS  =
            // ================

            // DONE - Add MoveBehaviour > Random movement around checkpoint
            // DONE - Add DeathHebaviour for The Worm(Head) > Stop all body parts moves and set them OnHeadDeath
            // DONE - Add DeathBehaviour for The Worm(Body) > Shoot OnDestruction
        }
    }

    public class TODOList
    {
        //TO DO:
        // ok - Shield Bonus
        // ok - Shield Mechanics
        // ok - Add satisfying compponent loot display in EndGameScreen
        // ok - Creates a default SquadronData class CTOR returning simplest SquadronData for new prodiles.
        // ok - Creates Profile Handler.cs: Profile NewProfile()
        // ok - Create Profile.ResetProfile();
        // ok - Profile Handler.cs: Profile NewProfile() : is launched if no valid latest save
        // ok - SquadronData is now save in profile correctly;
        // ok - Update : UI_Update.cs
        //      ok - Button : back to mainMenu
        //      ok - Button template : switch states(previous/next)
        //          ok - Next/Previous States Mechanics
        //      ok - Fonctionnal Squadron Display 
        //      ok - Functionnal Member Display
        //      ok - Functionnal Module Display
        // ok - Tools new fctn: int NewIndex( bool isNext_ifNotPrevious, int currentIndex) 
        // ok - ModuleData.cs:
        //      ok - Add [m_tier: int]
        //      ok - Add fnctn Sprite GetSprite()
        // ok - Create a Module_Factory class
        //      ok - RandomModule() : ModuleData 
        // ok - Factory.cs :
        //      ok - Dice_BonusTier(int tier) :  int 
        //      ok - m_moduleFactory : Module_Factory
        // ok - Creates FinalLoot.cs:
        //      ok - m_options : ModuleData[3]
        // - EndGame_ApplicationState:
        //      ok - m_finalLoot : FinalLoot
        //      ok - Chest FinalLoot based on Score : "pick 1 option out of 3" style
        //          ok - FinalLoot_HiddenDisplay(); 
        //          ok - FinalLoot_DiscoveredDisplay();
        //          ok - FinalLoot_Open(int selection);
        // ok - UI_Endgame.cs & prefab :
        //      ok - Display_FinalLoot.prefab
        //          ok - Button_LootOption.prefab
        //      ok - Link buttons to UI_EnGame class fields
        // - highScore: 918230 v0.0.02    
        //
        // ok - component stats mechanics
        //      ok - Create stats panel Prefab.
        //      ok - class ModuleStat
        //      ok - class ModuleStats_Factory: 
        //          ok - GetStats(Module module) : ModuleStat[]
        // ok - ScrollPanel.prefab
        //
        // - 
        // ok - Deposit.cs:
        //     later - mining should be more rewarding than shooting it.
        //
        // - Recharge raate on shield and drones (is used when pickip up a drone and no drone slot free, converted to energy);
        // - Ship/Module Update Mechanics.
        // - Create a Reset Profile button in MainMenu
        // - Update gameInfo with last achieved wave number.
        // delayed - Factory.cs:  Dice_FinalLoot() : FinalLoot (delay : FinalLootObject not complex enough)
        // delayed - (need sprites) - UI_Game.cs : image + Text pop-Up On bonus pickup
        // delayed - UI_Upgrade.cs + prefab
        //      ok - to do: Panel m_moduleStats_Display;
        //      ok - to do: Sprite m_moduleSprite;
        //      delayed - to do: Panel m_shipStats_Display; 
        //      delayed (need sprites) - to do: Sprite m_shipSprite;
        // - Creates bonus rarity for shields and repairDrones bonuses
        // - Remove all _lifeTime updates from Bonuses and replace with Map.IsOnScreen check (as done in repairbonus.cs)
        // - dans UI_EndGame. cs possible de caluler et afficher une mention a partir des loot et du score? (: viur 'NOTE1' dans UI_EndGame.cs)
    }
}

